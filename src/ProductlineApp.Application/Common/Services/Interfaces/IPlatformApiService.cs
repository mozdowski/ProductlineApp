using ProductlineApp.Domain.Aggregates.Listing;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;

namespace ProductlineApp.Application.Common.Services.Interfaces;

public interface IPlatformApiService
{
    string GetAuthorizationUrl(string state);

    Task<string> GetAccessTokenAsync(string code);

    Task<IEnumerable<Domain.Aggregates.Order.Order>> GetOrdersAsync();

    Task<IEnumerable<Listing>> GetListingsAsync();

    Task<string> CreateListingAsync(Listing listing);

    Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(IEnumerable<string> listingIds);

    Task WithdrawListingAsync(string listingId);

    Task PublishListingAsync(string listingId);
}
