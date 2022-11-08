using ProductlineApp.Domain.Common;

namespace ProductlineApp.Domain.Entities;

public abstract class Buyer : Entity
{
    protected Buyer(
        Guid id,
        string username,
        string accountUrl,
        Bid firstBid,
        Marketplace marketplace)
        : base(id)
    {
        this.Username = username;
        this.AccountUrl = accountUrl;
        this.Marketplace = marketplace;
        this.CurrentBids.Add(firstBid);
    }

    public string Username { get; private set; }

    public string AccountUrl { get; private set; }

    public ICollection<Bid> CurrentBids { get; } = new HashSet<Bid>();

    public ICollection<Bid> FinishedBids { get; } = new HashSet<Bid>();

    public virtual Marketplace Marketplace { get; private set; }
}
