namespace ProductlineApp.Domain.Aggregates.Listing.ValueObjects
{
    public record ListingId
    {
        private ListingId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static ListingId CreateUnique()
        {
            return new ListingId(Guid.NewGuid());
        }

        public static ListingId Create(Guid value)
        {
            return new ListingId(value);
        }
    }
}
