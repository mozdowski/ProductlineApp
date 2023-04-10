using ProductlineApp.Infrastructure.Models;

namespace ProductlineApp.Infrastructure.ExternalServices.Amazon;

public interface IAmazonApiClient
{
    Task<string> GetAuthorizationUrlAsync();

    Task<AmazonTokenResponse> GetAccessTokenAsync(string code);
    // Task<string> GetAuthorizationUrlAsync(string state);
    //
    // Task<string> GetAccessTokenAsync(string code);
    //
    // Task<IEnumerable<AmazonOrder>> GetOrdersAsync(string accessToken);
    //
    // Task<IEnumerable<AmazonInventory>> GetInventoryAsync(string accessToken);
    //
    // Task<string> CreateListingAsync(string accessToken, Listing listing);
    //
    // Task<IEnumerable<ListingStatus>> GetListingStatusesAsync(string accessToken, IEnumerable<string> listingIds);
    //
    // Task WithdrawListingAsync(string accessToken, string listingId);
}
