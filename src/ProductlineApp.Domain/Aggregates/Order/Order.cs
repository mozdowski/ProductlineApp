using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Domain.Aggregates.Order;

public class Order : AggregateRoot<OrderId>
{
    private readonly List<OrderLine> _orderLines;
    private readonly List<Document> _documents = new();

    private Order(
        OrderId id,
        UserId ownerId,
        List<OrderLine> orderLines,
        ShippingAddress shippingAddress,
        BillingAddress billingAddress,
        PlatformId platformId,
        string PlatformOrderId,
        OrderStatus status,
        DateTime placedAt,
        bool isPaid,
        decimal subtotalPrice,
        decimal deliveryCost,
        DateTime? deliveryDate)
        : base(id)
    {
        this._orderLines = orderLines;
        this.OwnerId = ownerId ?? throw new ArgumentNullException(nameof(ownerId));
        this.ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
        this.BillingAddress = billingAddress ?? throw new ArgumentNullException(nameof(billingAddress));
        this.PlatformId = platformId;
        this.PlatformOrderId = PlatformOrderId;
        this.Status = status;
        this.PlacedAt = placedAt;
        this.IsPaid = isPaid;
        this.SubtotalPrice = subtotalPrice;
        this.DeliveryCost = deliveryCost;
        this.DeliveryDate = deliveryDate;
    }

    public Order()
    {
    }

    public UserId OwnerId { get; private set; }

    public ShippingAddress ShippingAddress { get; private set; }

    public BillingAddress BillingAddress { get; private set; }

    public IReadOnlyCollection<OrderLine> OrderLines => this._orderLines.AsReadOnly();

    public IReadOnlyCollection<Document> Documents => this._documents.AsReadOnly();

    public PlatformId PlatformId { get; private set; }

    public string PlatformOrderId { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTime PlacedAt { get; private set; }

    public bool IsPaid { get; set; }

    public decimal SubtotalPrice { get; set; }

    public decimal DeliveryCost { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public decimal TotalAmount => this.SubtotalPrice + this.DeliveryCost;

    public void AddOrderLine(OrderLine orderLine)
    {
        if (orderLine is null)
        {
            throw new ArgumentNullException(nameof(orderLine));
        }

        this._orderLines.Add(orderLine);
    }

    public void AddOrderLines(IEnumerable<OrderLine> orderLines)
    {
        this._orderLines.AddRange(orderLines);
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
        UserId ownerId,
        IEnumerable<OrderLine> orderLines,
        ShippingAddress shippingAddress,
        BillingAddress billingAddress,
        PlatformId platformId,
        string platformOrderId,
        OrderStatus status,
        DateTime placedAt,
        bool isPaid,
        decimal subtotalPrice,
        decimal deliveryCost,
        DateTime? deliveryDate)
    {
        var id = OrderId.CreateUnique();

        var enumerable = orderLines.ToList();
        if (!enumerable.Any())
            throw new ArgumentException("There should be at least one OrderLine to create an Order");

        return new Order(
            id,
            ownerId,
            enumerable,
            shippingAddress,
            billingAddress,
            platformId,
            platformOrderId,
            status,
            placedAt,
            isPaid,
            subtotalPrice,
            deliveryCost,
            deliveryDate);
    }
}
