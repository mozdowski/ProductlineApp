using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Infrastructure.ExternalServices.Common;

public class UploadFileService : IUploadFileService
{
    public async Task<IFile> UploadFileAsync(IFormFile fileData, FileType fileType)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<IFile>> UploadMultiFileAsync(IEnumerable<FileUploadModel> filesUploadData)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteFileAsync(string fileName, string url)
    {
        throw new NotImplementedException();
    }
}
