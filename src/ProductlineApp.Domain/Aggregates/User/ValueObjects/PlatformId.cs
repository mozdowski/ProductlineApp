namespace ProductlineApp.Domain.Aggregates.User.ValueObjects;

public record PlatformId
{
    private PlatformId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static PlatformId CreateUnique()
    {
        return new PlatformId(Guid.NewGuid());
    }

    public static PlatformId Create(Guid value)
    {
        return new PlatformId(value);
    }
}
