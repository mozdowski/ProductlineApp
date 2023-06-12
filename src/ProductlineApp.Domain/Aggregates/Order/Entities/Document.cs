using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.Order.Entities;

public class Document : Entity<DocumentId>, IFile
{
    private Document(
        DocumentId id,
        string name,
        Uri url,
        OrderId orderId)
        : base(id)
    {
        this.Name = name;
        this.Url = url;
        this.OrderId = orderId;
    }

    public string Name { get; set; }

    public Uri Url { get; set; }

    public OrderId OrderId { get; private init; }

    public static Document Create(
        string name,
        string url,
        OrderId orderId)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Document name cannot be null or empty");

        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            throw new ArgumentException("Invalid document URL.", nameof(url));

        return new Document(
            DocumentId.CreateUnique(),
            name,
            uri,
            orderId);
    }
}
