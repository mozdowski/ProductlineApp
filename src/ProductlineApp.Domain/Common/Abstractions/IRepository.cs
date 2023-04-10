using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Domain.Common.Abstractions;

public interface IRepository<T, in TId> : IRepositoryBase
    where T : AggregateRoot<TId>
    where TId : notnull
{
    Task<T> GetByIdAsync(TId id);

    Task<IEnumerable<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task RemoveAsync(TId id);

    Task<IEnumerable<T>> GetAllByUserIdAsync(UserId userId);
}
