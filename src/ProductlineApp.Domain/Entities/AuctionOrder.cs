using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Exceptions;

namespace ProductlineApp.Domain.Entities;

public class AuctionOrder : AggregateRoot
{
    public AuctionOrder(
        Guid id,
        Auction auction,
        int productQuantity)
        : base(id)
    {
        this.Auction = auction;

        if ((productQuantity > 0) && (productQuantity < auction.Quantity))
        {
            this.ProductQuantity = productQuantity;
        }
        else
        {
            throw new InvalidQuantityException(this);
        }
    }

    public Auction Auction { get; private set; }

    public int ProductQuantity { get; private set; }
}
