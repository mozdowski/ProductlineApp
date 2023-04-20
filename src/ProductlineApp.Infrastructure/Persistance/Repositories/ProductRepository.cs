using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<Product> GetByIdAsync(ProductId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(ProductId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllByUserIdAsync(UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProductWithUserIdAsync(ProductId productId, UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task AddCategoryAsync(UserId userId, Category category)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetCategoriesAsync(UserId userId)
    {
        throw new NotImplementedException();
    }
}
