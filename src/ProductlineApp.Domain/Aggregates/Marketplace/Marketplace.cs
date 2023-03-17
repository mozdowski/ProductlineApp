using ProductlineApp.Domain.Aggregates.Marketplace.ValueObjects;
using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Exceptions;

namespace ProductlineApp.Domain.Aggregates.Marketplace;

public class Marketplace : Entity<MarketplaceId>
{
    public Marketplace(
        Guid id,
        string name,
        string url)
        : base(id)
    {
        this.Name = name;
        this.Url = url;
        this.Auctions = new HashSet<Auction>();
    }

    public string Name { get; private set; }

    public string Url { get; private set; }

    public virtual ICollection<Auction> Auctions { get; private set; }

    public void AddAuction(Auction auction)
    {
        if (!this.Auctions.Contains(auction))
        {
            this.Auctions.Add(auction);
        }
        else
        {
            throw new MarketplaceContainsAuctionException(this, auction);
        }
    }
}
