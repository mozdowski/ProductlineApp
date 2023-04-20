using Microsoft.AspNetCore.Http;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.Common.Services.Interfaces;

public interface IUploadFileService
{
    public Task<IFile> UploadFileAsync(IFormFile fileData, FileType fileType);

    public Task<IEnumerable<IFile>> UploadMultiFileAsync(IEnumerable<FileUploadModel> filesUploadData);

    public Task DeleteFileAsync(string fileName, string url);
}
