using ProductlineApp.Domain.Entities;

namespace ProductlineApp.Domain.Repositories.Sellers;

public interface ISellerRepository
{
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    void Add(User seller);
}
