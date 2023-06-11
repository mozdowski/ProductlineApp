namespace ProductlineApp.Domain.Common.Abstractions;

public interface IFile
{
    string Name { get; set; }

    Uri Url { get; set; }
}
