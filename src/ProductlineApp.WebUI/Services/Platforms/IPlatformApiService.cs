using ProductlineApp.Domain.Aggregates.Listing.Entities;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;
using ProductlineApp.Domain.Aggregates.Order;
using ProductlineApp.Domain.Aggregates.Product;

namespace ProductlineApp.WebUI.Services.Platforms;

public interface IPlatformApiService
{
    Task<string> ConnectUserAsync(string userId, string state);

    Task<string> CreateListingAsync(string accessToken, ListingInstance listingInstance);

    Task<IEnumerable<Order>> GetOrdersAsync(string accessToken);

    Task<IEnumerable<Product>> GetInventoryAsync(string accessToken);

    Task WithdrawListingAsync(string accessToken, string listingId);

    Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(string accessToken, IEnumerable<ListingInstanceId> listingIds);
}
