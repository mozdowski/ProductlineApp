namespace ProductlineApp.Domain.Aggregates.Auction.ValueObjects
{
    public class AuctionId
    {
        private AuctionId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static AuctionId CreateUnique()
        {
            return new AuctionId(Guid.NewGuid());
        }

        public static AuctionId Create(Guid value)
        {
            return new AuctionId(value);
        }
    }
}
