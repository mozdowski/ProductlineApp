using ProductlineApp.Domain.Aggregates.Auction.ValueObjects;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Common;

namespace ProductlineApp.Domain.Aggregates.Order.Entities;

public class PartialOrder : Entity<PartialOrder>
{
    public PartialOrder(
        AuctionId auctionId,
        OrderId orderId,
        int productQuantity,
        decimal price)
        : base()
    {
        this.OrderId = orderId;
        this.AuctionId = auctionId;
        this.ProductQuantity = productQuantity;
        this.Price = price;
    }

    public OrderId OrderId { get; }

    public AuctionId AuctionId { get; }

    public int ProductQuantity { get; }

    public decimal Price { get; }
}
