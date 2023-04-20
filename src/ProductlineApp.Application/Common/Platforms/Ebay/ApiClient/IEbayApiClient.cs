using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Platforms.Ebay.ApiClient;

public interface IEbayApiClient
{
    string GetAuthorizationUrl();

    Task<EbayTokenResponse> GetAccessTokenAsync(string code);

    Task<EbayTokenResponse> GetRefreshTokenAsync(string refreshToken);

    Task CreateOrReplaceInventoryItem(string accessToken, string sku, EbayCreateOrReplaceInventoryRequest requestBody);

    Task<EbayInventoryItems> GetInventoryItems(string accessToken, int? limit, int? offset);

    Task<EbayInventoryLocations> GetInventoryLocations(string accessToken, int? offset, int? limit);

    Task<string> CreateOffer(string accessToken, EbayCreateOrReplaceInventoryRequest requestBody);

    Task<EbayOffersReponse> GetOffers(string accessToken);

    Task WithdrawOffer(string accessToken, string offerId);

    // update offer
    // publish offer
    // withdraw offer
    // bulk CRUD
}
