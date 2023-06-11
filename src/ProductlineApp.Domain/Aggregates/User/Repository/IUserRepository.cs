using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.User.Repository;

public interface IUserRepository : IRepositoryBase
{
    public Task<User?> GetUserByEmailAsync(string email);

    public Task<User?> GetUserByIdAsync(UserId userId);

    public Task<bool> IsUserExistingAsync(string email);

    public Task<bool> IsUserExistingAsync(UserId userId);

    public Task AddAsync(User user);

    public Task UpdateUserAsync(User user);

    public Task AddPlatformConnection(User user, PlatformConnection platformConnection);

    public Task<IEnumerable<PlatformConnection>> GetUserPlatformConnectionsAsync(UserId userId);

    public Task<string> GetUserPlatformToken(UserId userId, PlatformId platformId);

    Task<(User? User, string? Salt)> GetByEmailWithSaltAsync(string email);

    Task<IEnumerable<PlatformConnection>> GetAllPlatformConnectionsAsync();

    Task<IEnumerable<User>> GetUsersBatchAsync(int pageNumber, int pageSize);
}
