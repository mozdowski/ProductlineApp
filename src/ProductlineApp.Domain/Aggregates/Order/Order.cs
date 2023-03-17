using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Entities;

public class Order : AggregateRoot<OrderId>
{
    private readonly List<PartialOrder> _partialOrders = new();

    public Order(
        IEnumerable<PartialOrder> auctionOrders)
        : base()
    {
        this.PlacedAt = DateTime.Now;
    }

    public UserId UserId { get; private set; }

    public IReadOnlyList<PartialOrder> PartialOrders => this._partialOrders.AsReadOnly();

    public decimal TotalPrice { get; }

    public ICollection<Document> Documents { get; } = new HashSet<Document>();

    public PaymentStatus PaymentStatus { get; private set; }

    public DateTime PlacedAt { get; }

    public void AttachDocument(Document document)
    {
        this.Documents.Add(document);
    }
}
