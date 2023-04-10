using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Order.Entities;

public class OrderLine : Entity<OrderLineId>
{
    private const int MinimumQuantity = 1;

    private OrderLine(
        OrderLineId id,
        ListingInstanceId listingInstanceId,
        OrderId orderId,
        ProductId productId,
        int quantity,
        decimal price)
        : base(id)
    {
        this.ListingInstanceId = listingInstanceId;
        this.OrderId = orderId;
        this.ProductId = productId;
        this.Quantity = quantity;
        this.Price = price;
    }

    public ListingInstanceId ListingInstanceId { get; private set; }

    public OrderId OrderId { get; private set; }

    public ProductId ProductId { get; private set; }

    private int _quantity;

    public int Quantity
    {
        get => this._quantity;
        set => this._quantity = value >= MinimumQuantity ?
            value : throw new ArgumentException($"Quantity cannot be less than {MinimumQuantity}");
    }

    public decimal Price { get; private set; }

    public decimal TotalAmount => this.Quantity * this.Price;

    public static OrderLine Create(
        ListingInstanceId listingInstanceId,
        OrderId orderId,
        ProductId productId,
        int quantity,
        decimal price)
    {
        var id = OrderLineId.CreateUnique();

        return new OrderLine(id, listingInstanceId, orderId, productId, quantity, price);
    }
}

