using Microsoft.EntityFrameworkCore;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductlineDbContext _dbContext;

    public ProductRepository(
        ProductlineDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Product?> GetByIdAsync(ProductId id)
    {
        return await this._dbContext.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Product? entity)
    {
        await this._dbContext.Products.AddAsync(entity);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        if (this._dbContext.Entry(entity).State is EntityState.Detached)
        {
            throw new Exception("Product not attached to the context");
        }

        await this._dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Product? product)
    {
        if (this._dbContext.Entry(product).State is EntityState.Detached)
        {
            throw new Exception("Product not attached to the context");
        }

        this._dbContext.Products.Remove(product);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product?>> GetAllByUserIdAsync(UserId userId)
    {
        var products = await this._dbContext.Products.Where(x => x.OwnerId == userId).ToListAsync();
        return products;
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

    public async Task<Product?> GetProductBySku(string sku)
    {
        return await this._dbContext.Products.FirstOrDefaultAsync(x => x.Sku == sku);
    }

    public async Task<IEnumerable<string>> GetSkusByIds(IEnumerable<ProductId> productIds, UserId userId)
    {
        return await this._dbContext.Products.Where(x => x.OwnerId == userId).Where(x => productIds.Contains(x.Id))
            .Select(x => x.Sku).ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetUserProductsByIds(IEnumerable<ProductId> productIds, UserId userId)
    {
        return await this._dbContext.Products.Where(x => x.OwnerId == userId).Where(x => productIds.Contains(x.Id))
            .ToListAsync();
    }

    public async Task<Product?> GetProductsBySkuOrId(string id)
    {
        var isProductId = Guid.TryParse(id, out var productId);

        return await this._dbContext.Products
            .FirstOrDefaultAsync(x => x.Sku == id || (isProductId && productId == x.Id.Value));
    }
}
