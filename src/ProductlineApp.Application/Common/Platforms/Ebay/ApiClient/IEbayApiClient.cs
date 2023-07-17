using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Platforms.Ebay.ApiClient;

public interface IEbayApiClient
{
    string GetAuthorizationUrl(string platformId);

    Task<EbayTokenResponse> GetAccessTokenAsync(string code, string platformId);

    Task<EbayTokenResponse> GetRefreshTokenAsync(string refreshToken, string platformId);

    Task CreateOrReplaceInventoryItem(string accessToken, string sku, EbayCreateOrReplaceInventoryRequest requestBody);

    Task<EbayInventoryItems> GetInventoryItems(string accessToken, int? limit, int? offset);

    Task<EbayInventoryLocations> GetInventoryLocations(string accessToken, int? offset, int? limit);

    Task<string> CreateOffer(string accessToken, EbayCreateOfferRequest requestBody);

    // Task<IEnumerable<EbayOffersReponse.Offer>> GetOffers(string accessToken);

    public Task<IEnumerable<EbayOffersReponse.Offer>> GetOffers(string accessToken, IEnumerable<string> offerIds);

    Task WithdrawOffer(string accessToken, string offerId);

    Task<string> PublishOffer(string accessToken, string offerId);

    Task<EbaySuggestedCategoriesResponse> GetCategories(string accessToken, string phrase);

    Task<EbayCategoryTreeResponse> GetCategories(string accessToken);

    Task<EbayAspectsResponse> GetAspectsForCategory(string accessToken, string categoryId);

    Task<IEnumerable<EbayOrderResponse>> GetOrders(string accessToken, IEnumerable<string> orderIds);

    Task<IEnumerable<EbayLocationsResponse.LocationItem>> GetMerchantLocationKeys(string accessToken);

    Task<string> GetCategoryNameById(string accessToken, string categoryId);

    Task<EbayFulfillmentPoliciesResponse> GetFulfillmentPolicies(string accessToken, string marketplaceId);

    Task<EbayPaymentPoliciesResponse> GetPaymentPolicies(string accessToken, string marketplaceId);

    Task<EbayReturnPoliciesResponse> GetReturnPolicies(string accessToken, string marketplaceId);

    Task UpdateOffer(string accessToken, string offerId, EbayUpdateOfferRequest requestBody);

    Task<EbayProductDetailsResponse> GetProductDetails(string accessToken, string sku);
}
