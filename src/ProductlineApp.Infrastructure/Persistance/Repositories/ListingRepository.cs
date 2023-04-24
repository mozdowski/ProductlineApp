using ProductlineApp.Domain.Aggregates.Listing;
using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class ListingRepository : IListingRepository
{
    public async Task<Listing> GetByIdAsync(ListingId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Listing>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Listing entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Listing entity)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(Listing id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Listing>> GetAllByUserIdAsync(UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ListingInstance>> GetAllListingInstancesByListingId(ListingId listingId)
    {
        throw new NotImplementedException();
    }

    public async Task<ListingInstance> GetListingInstanceById(ListingInstanceId listingInstanceId)
    {
        throw new NotImplementedException();
    }
}
