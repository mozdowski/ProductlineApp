using Microsoft.AspNetCore.Http;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.Common.Services.Interfaces;

public interface IUploadFileService
{
    Task<IFile> UploadFileAsync(IFormFile fileData, FileType fileType);

    Task<IEnumerable<IFile>> UploadMultiFileAsync(IEnumerable<FileUploadModel> filesUploadData);

    Task DeleteFileAsync(string fileName);

    Task DeleteMultiFilesAsync(IEnumerable<string> fileNames);
}
