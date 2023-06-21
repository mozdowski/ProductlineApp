using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Order.Entities;

public class OrderLine : Entity<OrderLineId>
{
    private const int MinimumQuantity = 1;
    private int _quantity;

    private OrderLine(
        OrderLineId id,
        string sku,
        string platformListingId,
        int quantity,
        decimal price,
        string name)
        : base(id)
    {
        this.Quantity = quantity;
        this.Price = price;
        this.PlatformListingId = platformListingId;
        this.Sku = sku;
        this.Name = name;
    }

    public OrderLine()
    {
    }

    public string PlatformListingId { get; set; }

    public string Sku { get; private set; }

    public string Name { get; private set; }

    public int Quantity
    {
        get => this._quantity;
        set => this._quantity = value >= MinimumQuantity ?
            value : throw new ArgumentException($"Quantity cannot be less than {MinimumQuantity}");
    }

    public decimal Price { get; private set; }

    public decimal TotalAmount => this.Quantity * this.Price;

    public static OrderLine Create(
        string platformListingId,
        string sku,
        int quantity,
        decimal price,
        string name)
    {
        var id = OrderLineId.CreateUnique();

        return new OrderLine(id, sku, platformListingId, quantity, price, name);
    }
}
