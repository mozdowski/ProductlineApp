using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Infrastructure.ExternalServices.Azure;

public class AzureStorageService : IUploadFileService
{
    private readonly BlobContainerClient _containerClient;
    private readonly string _connectionString;

    public AzureStorageService(
        IConfiguration configuration)
    {
        this._connectionString = configuration.GetConnectionString("azureStorage");

        var blobServiceClient = new BlobServiceClient(this._connectionString);
        this._containerClient = blobServiceClient.GetBlobContainerClient("productline-files");
        this._containerClient.CreateIfNotExists();
    }

    public async Task<IFile> UploadFileAsync(IFormFile fileData, FileType fileType)
    {
        var fileName = fileType == FileType.IMAGE ?
            Guid.NewGuid().ToString() :
            Guid.NewGuid() + "-" + fileData.FileName.Replace(" ", "_").Normalize();
        var blobClient = this._containerClient.GetBlobClient(fileName);

        await using var stream = fileData.OpenReadStream();
        await blobClient.UploadAsync(stream, new BlobUploadOptions
        {
            HttpHeaders = new BlobHttpHeaders
            {
                ContentType = fileData.ContentType,
            },
        });

        DateTimeOffset startTime = DateTimeOffset.UtcNow;
        DateTimeOffset expiryTime = startTime.Add(new TimeSpan(500, 0, 0, 0));

        var blobSasBuilder = new BlobSasBuilder
        {
            BlobContainerName = this._containerClient.Name,
            BlobName = fileName,
            ContentDisposition = $"attachment; filename={fileName}",
            ContentType = fileData.ContentType,
            Protocol = SasProtocol.Https,
            ExpiresOn = expiryTime,
        };

        blobSasBuilder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.Delete);

        var storageAccount = CloudStorageAccount.Parse(this._connectionString);
        string sasToken = blobSasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(storageAccount.Credentials.AccountName, storageAccount.Credentials.ExportBase64EncodedKey())).ToString();

        var blobUri = blobClient.Uri;
        var blobUriBuilder = new UriBuilder(blobUri)
        {
            Query = sasToken,
        };

        return fileType switch
        {
            FileType.IMAGE => Image.Create(fileName, blobUriBuilder.Uri),
            FileType.DOCUMENT => DocumentFile.Create(fileName, blobUriBuilder.Uri),
            _ => throw new Exception("No file type matched"),
        };
    }

    public async Task<IEnumerable<IFile>> UploadMultiFileAsync(IEnumerable<FileUploadModel> filesUploadData)
    {
        var uploadedFiles = new List<IFile>();

        foreach (var fileData in filesUploadData)
        {
            var uploadedFile = await this.UploadFileAsync(fileData.FileDetails, fileData.FileType);
            uploadedFiles.Add(uploadedFile);
        }

        return uploadedFiles;
    }

    public async Task DeleteFileAsync(string fileName)
    {
        var blobClient = this._containerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }

    public async Task DeleteMultiFilesAsync(IEnumerable<string> fileNames)
    {
        var blobsToDelete = fileNames.Select(fileName => this._containerClient.GetBlobClient(fileName));
        var blobDeleteTasks = blobsToDelete.Select(blob => blob.DeleteAsync());

        await Task.WhenAll(blobDeleteTasks);
    }
}
