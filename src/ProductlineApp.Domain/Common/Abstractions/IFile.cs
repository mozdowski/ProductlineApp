namespace ProductlineApp.Domain.Common.Abstractions;

public interface IFile
{
    public string Name { get; set; }

    public Uri Url { get; set; }
}
