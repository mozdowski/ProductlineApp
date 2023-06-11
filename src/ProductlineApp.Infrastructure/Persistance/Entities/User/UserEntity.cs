using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Entities.User;

public class UserEntity
{
    public UserId Id { get; set; }

    public string Username { get; set; }

    public string HashedPassword { get; set; }

    public string Salt { get; set; }

    public string Email { get; set; }

    public ICollection<PlatformConnectionEntity> PlatformConnections { get; set; }
}
