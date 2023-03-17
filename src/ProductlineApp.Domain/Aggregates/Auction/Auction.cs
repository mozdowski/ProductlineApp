using ProductlineApp.Domain.Aggregates.Auction.ValueObjects;
using ProductlineApp.Domain.Aggregates.Marketplace.ValueObjects;
using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Domain.Aggregates.Auction;

public class Auction : AggregateRoot<AuctionId>
{
    public Auction(
        BidId bidId,
        User owner,
        DateTime startDateTime,
        Category category,
        MarketplaceId marketplaceId,
        int quantity,
        AuctionStatus auctionStatus,
        int secondsToExpire,
        DateTime endDateTime,
        bool isTemplate,
        bool isBidEnabled)
    {
        this.BidId = bidId;
        this.Owner = owner;
        this.StartDateTime = startDateTime;
        this.Category = category;
        this.MarketplaceId = marketplaceId;
        this.Quantity = quantity;
        this.AuctionStatus = auctionStatus;
        this.SecondsToExpire = secondsToExpire;
        this.EndDateTime = endDateTime;
        this.IsTemplate = isTemplate;
        this.IsBidEnabled = isBidEnabled;
    }

    public BidId BidId { get; private set; }

    public User Owner { get; private set; }

    public DateTime StartDateTime { get; private set; }

    public Category Category { get; private set; }

    public MarketplaceId MarketplaceId { get; }

    public int Quantity { get; private set; }

    public AuctionStatus AuctionStatus { get; private set; }

    public int SecondsToExpire { get; private set; }

    public DateTime EndDateTime { get; private set; }

    public bool IsTemplate { get; private set; }

    public bool IsBidEnabled { get; private set; }
}
