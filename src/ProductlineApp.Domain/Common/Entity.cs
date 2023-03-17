namespace ProductlineApp.Domain.Common;

public abstract class Entity<TId> : AuditableEntity, IEquatable<Entity<TId>>
    where TId : notnull
{
    protected Entity(TId id)
    {
        this.Id = id;
    }

    protected Entity()
    {
    }

    public TId Id { get; private init; }

    public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity<TId>? first, Entity<TId>? second)
    {
        return !(first == second);
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != this.GetType())
        {
            return false;
        }

        return this.Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        if (obj is not Entity<TId> entity)
        {
            return false;
        }

        return this.Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}
