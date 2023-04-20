namespace ProductlineApp.Domain.Aggregates.Order.ValueObjects;

public record OrderLineId
{
    private OrderLineId(Guid value)
    {
        this.Value = value;
    }

    public Guid Value { get; private set; }

    public static OrderLineId CreateUnique()
    {
        return new OrderLineId(Guid.NewGuid());
    }

    public static OrderLineId Create(Guid value)
    {
        return new OrderLineId(value);
    }
}
