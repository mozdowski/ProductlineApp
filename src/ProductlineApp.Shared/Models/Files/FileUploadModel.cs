using Microsoft.AspNetCore.Http;

namespace ProductlineApp.Shared.Models.Files;

public record FileUploadModel(IFormFile FileDetails, FileType FileType);
