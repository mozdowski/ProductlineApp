using ProductlineApp.Domain.Entities;

namespace ProductlineApp.Domain.Repositories.Products;

public interface IProductRepository
{
    void Add(Product product);
}