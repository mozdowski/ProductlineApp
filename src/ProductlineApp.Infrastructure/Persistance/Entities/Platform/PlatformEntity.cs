using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Entities.Platform;

public record PlatformEntity(PlatformId Id, string Name, string Url);
