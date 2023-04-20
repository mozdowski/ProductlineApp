using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Entities.User;

public class PlatformConnectionEntity
{
    public PlatformConnectionId Id { get; set; }

    public PlatformId PlatformId { get; set; }

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public DateTime ExpirationDate { get; set; }

    public UserId UserId { get; set; }
}
