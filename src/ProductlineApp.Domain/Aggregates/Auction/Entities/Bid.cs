using ProductlineApp.Domain.Aggregates.Auction.ValueObjects;
using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Domain.Aggregates.Auction.Entities;

public class Bid : Entity<Bid>
{
    public Bid(
        AuctionId auctionId,
        decimal startPrice,
        decimal currentPrice,
        decimal finalPrice,
        BidType type)
    {
        this.AuctionId = auctionId;
        this.StartPrice = startPrice;
        this.CurrentPrice = currentPrice;
        this.FinalPrice = finalPrice;
        this.State = BidState.INITIALIZED;
        this.Type = type;
    }

    public AuctionId AuctionId { get; private set; }

    public decimal StartPrice { get; private set; }

    public decimal CurrentPrice { get; private set; }

    public decimal FinalPrice { get; private set; }

    public BidState State { get; private set; }

    public BidType Type { get; private set; }
}
