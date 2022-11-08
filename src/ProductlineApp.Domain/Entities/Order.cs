using ProductlineApp.Domain.Common;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Entities;

public class Order : Entity
{
    public Order(
        Guid id,
        Buyer buyer,
        IEnumerable<AuctionOrder> auctionOrders)
        : base(id)
    {
        this.Buyer = buyer;
        this.AuctionOrders = auctionOrders;
        this.PlacedAt = DateTime.Now;
    }

    public Buyer Buyer { get; private set; }

    public IEnumerable<AuctionOrder> AuctionOrders { get; private set; }

    public decimal TotalPrice => this.AuctionOrders.Sum(auctionOrder => auctionOrder.Auction.Bid.FinalPrice);

    public ICollection<Document> Documents { get; } = new HashSet<Document>();

    public PaymentStatus PaymentStatus { get; private set; }

    public DateTime PlacedAt { get; }

    public void AttachDocument(Document document)
    {
        this.Documents.Add(document);
    }
}
