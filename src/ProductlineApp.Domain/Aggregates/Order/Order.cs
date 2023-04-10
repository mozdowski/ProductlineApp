using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.Order;

public class Order : AggregateRoot<OrderId>
{
    private readonly List<OrderLine> _orderLines;
    private readonly List<Document> _documents = new();

    private Order(
        OrderId id,
        ListingInstanceId listingInstanceId,
        UserId ownerId,
        List<OrderLine> orderLines,
        Address shippingAddress)
        : base(id)
    {
        this._orderLines = orderLines;
        this.ListingInstanceId = listingInstanceId ?? throw new ArgumentNullException(nameof(listingInstanceId));
        this.OwnerId = ownerId ?? throw new ArgumentNullException(nameof(ownerId));
        this.ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
    }

    public ListingInstanceId ListingInstanceId { get; private set; }

    public UserId OwnerId { get; private set; }

    public Address ShippingAddress { get; private set; }

    public IReadOnlyCollection<OrderLine> OrderLines => this._orderLines.AsReadOnly();

    public IReadOnlyCollection<Document> Documents => this._documents.AsReadOnly();

    public decimal TotalAmount => this._orderLines.Sum(x => x.TotalAmount);

    public void AddOrderLine(OrderLine orderLine)
    {
        if (orderLine is null)
        {
            throw new ArgumentNullException(nameof(orderLine));
        }

        this._orderLines.Add(orderLine);
    }

    public void AddDocument(Document document)
    {
        if (document is null)
        {
            throw new ArgumentNullException(nameof(document));
        }

        this._documents.Add(document);
    }

    public static Order Create(
        ListingInstanceId listingInstanceId,
        UserId ownerId,
        IEnumerable<OrderLine> orderLines,
        Address shippingAddress)
    {
        var id = OrderId.CreateUnique();

        var enumerable = orderLines.ToList();
        if (!enumerable.Any())
            throw new ArgumentException("There should be at least one OrderLine to create an Order");

        return new Order(id, listingInstanceId, ownerId, enumerable, shippingAddress);
    }
}

