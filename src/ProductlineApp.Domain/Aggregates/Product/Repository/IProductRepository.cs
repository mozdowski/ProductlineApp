using ProductlineApp.Domain.Aggregates.Product.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Product.Repository;

public interface IProductRepository : IRepository<Product, ProductId>
{
    public Task DeleteProductWithUserIdAsync(ProductId productId, UserId userId);

    public Task AddCategoryAsync(UserId userId, Category category);

    public Task<Category> GetCategoriesAsync(UserId userId);
}
