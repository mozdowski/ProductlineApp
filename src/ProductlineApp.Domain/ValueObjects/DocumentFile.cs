using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.ValueObjects;

public sealed record DocumentFile : IFile
{
    private DocumentFile(string name, string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            throw new ArgumentException("Invalid platform URL.", nameof(url));

        this.Name = name;
        this.Url = uri;
    }

    private DocumentFile(string name, Uri uri)
    {
        this.Name = name;
        this.Url = uri;
    }

    private DocumentFile()
    {
    }

    public static DocumentFile Create(string url)
    {
        var name = url.Split('/')[^1].Split('.')[0];
        return new DocumentFile(name, url);
    }

    public static DocumentFile Create(string name, string url)
    {
        return new DocumentFile(name, url);
    }

    public static DocumentFile Create(string name, Uri uri)
    {
        return new DocumentFile(name, uri);
    }

    public string Name { get; set; }

    public Uri Url { get; set; }

    public bool Equals(DocumentFile? other)
    {
        if (other is null)
            return false;

        return this.Url.ToString().Equals(other.Url.ToString());
    }

    public override int GetHashCode()
    {
        return this.Url.GetHashCode();
    }
}
