using ProductlineApp.Domain.Entities;

namespace ProductlineApp.Domain.Repositories.Sellers;

public interface ISellerRepository
{
    Task<Seller> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    void Add(Seller seller);
}
