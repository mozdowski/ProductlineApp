using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Products.Repository;

public interface IProductRepository : IRepository<Product, ProductId>
{
    public Task AddCategoryAsync(UserId userId, Category category);

    public Task<Category> GetCategoriesAsync(UserId userId);

    public Task<Product?> GetProductBySku(string sku);

    public Task<IEnumerable<string>> GetSkusByIds(IEnumerable<ProductId> productIds, UserId userId);

    public Task<IEnumerable<Product?>> GetUserProductsByIds(IEnumerable<ProductId> productIds, UserId userId);

    Task<Product?> GetProductsBySkuOrId(string id);
}
