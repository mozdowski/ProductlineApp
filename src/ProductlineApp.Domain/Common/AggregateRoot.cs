namespace ProductlineApp.Domain.Common;

public abstract class AggregateRoot : Entity
{
    protected AgregateRoot(Guid id)
        : base(id)
    {
    }
}

