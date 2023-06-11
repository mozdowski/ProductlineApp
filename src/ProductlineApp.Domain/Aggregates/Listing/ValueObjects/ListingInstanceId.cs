namespace ProductlineApp.Domain.Aggregates.Listing.ValueObjects;

public record ListingInstanceId
{
    private ListingInstanceId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static ListingInstanceId CreateUnique()
    {
        return new ListingInstanceId(Guid.NewGuid());
    }

    public static ListingInstanceId Create(Guid value)
    {
        return new ListingInstanceId(value);
    }
}