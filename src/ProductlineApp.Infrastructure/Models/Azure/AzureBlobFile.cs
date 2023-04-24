using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Infrastructure.Models.Azure;

public class AzureBlobFile : IFile
{
    public string Name { get; set; }

    public Uri Url { get; set; }
}
