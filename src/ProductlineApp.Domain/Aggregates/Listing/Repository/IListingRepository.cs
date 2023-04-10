using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.Aggregates.Listing.Repository;

public interface IListingRepository : IRepository<Listing, ListingId>
{
    Task<IEnumerable<ListingInstance>> GetAllListingInstancesByListingId(ListingId listingId);

    Task<ListingInstance> GetListingInstanceById(ListingInstanceId listingInstanceId);
}
