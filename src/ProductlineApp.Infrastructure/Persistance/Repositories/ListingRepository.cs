using Microsoft.EntityFrameworkCore;
using ProductlineApp.Domain.Aggregates.Listing;
using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class ListingRepository : IListingRepository
{
    private readonly ProductlineDbContext _dbContext;

    public ListingRepository(
        ProductlineDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Listing> GetByIdAsync(ListingId id)
    {
        var listing = await this._dbContext.Listings.FindAsync(id);
        return listing;
    }

    public async Task<IEnumerable<Listing>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Listing entity)
    {
        await this._dbContext.Listings.AddAsync(entity);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Listing entity)
    {
        await this._dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Listing id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Listing>> GetAllByUserIdAsync(UserId userId)
    {
        return await this._dbContext.Listings.Where(x => x.OwnerId == userId).ToListAsync();
    }

    public async Task<IEnumerable<ListingInstance>> GetAllListingInstancesByListingId(ListingId listingId)
    {
        throw new NotImplementedException();
    }

    public async Task<ListingInstance> GetListingInstanceById(ListingId listingId, ListingInstanceId listingInstanceId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<string>> GetUsersPlatformListingsIds(UserId userId, PlatformId platformId)
    {
        return await this._dbContext.Listings
            .Include(x => x.Instances)
            .Where(x => x.OwnerId == userId)
            .SelectMany(x => x.Instances)
            .Where(x => x.PlatformId == platformId)
            .Select(x => x.PlatformListingId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ListingInstance>> GetByPlatformId(UserId userId, PlatformId platformId)
    {
        return await this._dbContext.Listings
            .AsNoTracking()
            .Include(x => x.Instances)
            .Where(x => x.OwnerId == userId)
            .SelectMany(x => x.Instances)
            .Where(x => x.PlatformId == platformId)
            .ToListAsync();
    }

    public async Task<IEnumerable<PlatformId>> GetPlatformsProductIsListedOn(ProductId productId)
    {
        return await this._dbContext.Listings
            .Include(x => x.Instances)
            .Where(x => x.ProductId == productId)
            .SelectMany(x => x.Instances)
            .Select(x => x.PlatformId)
            .ToListAsync();
    }

    public async Task<IDictionary<ProductId, List<PlatformId>>> GetPlatformsProductsAreListedOn(IEnumerable<ProductId> productIds)
    {
        var dictionary = productIds.ToDictionary(x => x, x => new List<PlatformId>());

        var listings = await this._dbContext.Listings
            .Where(x => productIds.Contains(x.ProductId))
            .Include(x => x.Instances)
            .ToListAsync();

        foreach (var listing in listings)
        {
            var platformIds = listing.Instances.Select(instance => instance.PlatformId).ToList();
            dictionary[listing.ProductId].AddRange(platformIds);
        }

        return dictionary;
    }

    public async Task<IEnumerable<PlatformId>> GetPlatformsUserHasListingsOn(UserId userId)
    {
        return await this._dbContext.Listings
        .Where(x => x.OwnerId == userId)
        .SelectMany(x => x.Instances)
        .Select(x => x.PlatformId)
        .ToListAsync();
    }

    public async Task<ListingInstance> GetByPlatformListingId(string platformListingId)
    {
        return await this._dbContext.Listings
            .AsNoTracking()
            .SelectMany(x => x.Instances)
            .FirstAsync(x => x.PlatformListingId == platformListingId);
    }

    public async Task<ListingInstance> GetListingInstanceById(ListingInstanceId listingInstanceId)
    {
        throw new NotImplementedException();
    }
}
