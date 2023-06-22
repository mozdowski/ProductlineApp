using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Products.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Listing.Repository;

public interface IListingRepository : IRepository<Listing, ListingId>
{
    Task<IEnumerable<ListingInstance>> GetAllListingInstancesByListingId(ListingId listingId);

    Task<ListingInstance> GetListingInstanceById(ListingId listingId, ListingInstanceId listingInstanceId);

    Task<IEnumerable<string>> GetUsersPlatformListingsIds(UserId userId, PlatformId platformId);

    Task<IEnumerable<PlatformId>> GetPlatformsProductIsListedOn(ProductId productId);

    Task<IDictionary<ProductId, List<PlatformId>>> GetPlatformsProductsAreListedOn(IEnumerable<ProductId> productIds);

    Task<IEnumerable<PlatformId>> GetPlatformsUserHasListingsOn(UserId userId);
}
