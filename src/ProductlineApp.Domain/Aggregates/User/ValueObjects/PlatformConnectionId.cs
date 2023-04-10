namespace ProductlineApp.Domain.Aggregates.User.ValueObjects;

public class PlatformConnectionId
{
    private PlatformConnectionId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static PlatformConnectionId CreateUnique()
    {
        return new PlatformConnectionId(Guid.NewGuid());
    }

    public static PlatformConnectionId Create(Guid value)
    {
        return new PlatformConnectionId(value);
    }
}