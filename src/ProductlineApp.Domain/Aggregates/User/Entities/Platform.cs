using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.User.Entities;

public class Platform : AggregateRoot<PlatformId>
{
    private Platform(PlatformId id, string name)
        : base(id)
    {
        this.Id = id;
        this.Name = name;
    }

    private Platform()
    {
    }

    public PlatformId Id { get; }

    public string Name { get; private set; }

    public static Platform Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Platform name cannot be null or empty.", nameof(name));

        return new Platform(
            PlatformId.CreateUnique(),
            name);
    }
}
