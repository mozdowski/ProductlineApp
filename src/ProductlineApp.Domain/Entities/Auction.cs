using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Domain.Entities;

public class Auction : Entity
{
    private Marketplace _marketplace;

    public Auction(
        Guid id,
        Bid bid,
        DateTime startDateTime,
        Category category,
        Marketplace marketplace,
        int quantity,
        AuctionStatus auctionStatus,
        int secondsToExpire,
        DateTime endDateTime,
        bool isTemplate,
        bool isBidEnabled)
        : base(id)
    {
        this.Bid = bid;
        this.StartDateTime = startDateTime;
        this.Category = category;
        this._marketplace = marketplace;
        this.Quantity = quantity;
        this.AuctionStatus = auctionStatus;
        this.SecondsToExpire = secondsToExpire;
        this.EndDateTime = endDateTime;
        this.IsTemplate = isTemplate;
        this.IsBidEnabled = isBidEnabled;
    }

    public Bid Bid { get; private set; }

    public DateTime StartDateTime { get; private set; }

    public Category Category { get; private set; }

    public Marketplace Marketplace
    {
        get => this._marketplace;
        set
        {
            this._marketplace = value;

            if (!this._marketplace.Auctions.Contains(this))
            {
                this._marketplace.AddAuction(this);
            }
        }
    }

    public int Quantity { get; private set; }

    public AuctionStatus AuctionStatus { get; private set; }

    public int SecondsToExpire { get; private set; }

    public DateTime EndDateTime { get; private set; }

    public bool IsTemplate { get; private set; }

    public bool IsBidEnabled { get; private set; }
}
