using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Domain.Entities;

public class Bid : Entity
{
    public Bid(
        Guid id,
        Auction auction,
        decimal startPrice,
        decimal currentPrice,
        decimal finalPrice,
        BidType type)
        : base(id)
    {
        this.Auction = auction;
        this.StartPrice = startPrice;
        this.CurrentPrice = currentPrice;
        this.FinalPrice = finalPrice;
        this.State = BidState.INITIALIZED;
        this.Type = type;
    }

    public Auction Auction { get; private set; }

    public decimal StartPrice { get; private set; }

    public decimal CurrentPrice { get; private set; }

    public decimal FinalPrice { get; private set; }

    public BidState State { get; private set; }

    public BidType Type { get; private set; }

    public ICollection<Buyer> BuyerList { get; private set; } = new HashSet<Buyer>();
}
