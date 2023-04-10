using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.User.Entities;

public class Platform : AggregateRoot<PlatformId>
{
    private Platform(PlatformId id, string name, Uri uri)
        : base(id)
    {
        this.Id = id;
        this.Name = name;
        this.Url = uri;
    }

    public PlatformId Id { get; }

    public string Name { get; private set; }

    public Uri Url { get; private set; }

    public static Platform Create(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Platform name cannot be null or empty.", nameof(name));

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            throw new ArgumentException("Invalid platform URL.", nameof(url));

        return new Platform(
            PlatformId.CreateUnique(),
            name,
            uri);
    }
}
