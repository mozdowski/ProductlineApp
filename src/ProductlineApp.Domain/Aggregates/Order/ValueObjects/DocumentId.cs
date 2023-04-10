namespace ProductlineApp.Domain.ValueObjects;

public record DocumentId
{
    private DocumentId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static DocumentId CreateUnique()
    {
        return new DocumentId(Guid.NewGuid());
    }

    public static DocumentId Create(Guid value)
    {
        return new DocumentId(value);
    }
}
