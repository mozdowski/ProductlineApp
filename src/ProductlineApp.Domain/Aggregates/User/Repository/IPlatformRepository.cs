using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.User.Repository;

public interface IPlatformRepository : IRepository<Platform, PlatformId>
{
    Task<Platform> GetByNameAsync(string name);

    Task<PlatformId?> GetIdByNameAsync(string name);

    Task<IDictionary<PlatformId, string>> GetPlatformNamesByIdsAsync(IEnumerable<PlatformId> platformIds);
}
