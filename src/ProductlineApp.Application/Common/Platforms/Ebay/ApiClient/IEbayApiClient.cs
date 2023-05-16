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

    Task<string> CreateOffer(string accessToken, EbayCreateOfferRequest requestBody);

    // Task<IEnumerable<EbayOffersReponse.Offer>> GetOffers(string accessToken);

    public Task<IEnumerable<EbayOffersReponse.Offer>> GetOffers(string accessToken, IEnumerable<string> offerIds);

    Task WithdrawOffer(string accessToken, string offerId);

    Task PublishOffer(string accessToken, string offerId);

    Task<EbaySuggestedCategoriesResponse> GetCategories(string accessToken, string phrase);

    Task<EbayCategoryTreeResponse> GetCategories(string accessToken);

    Task<EbayAspectsResponse> GetAspectsForCategory(string accessToken, string categoryId);

    Task<string> GetCategoryNameById(string accessToken, string categoryId);
    // update offer
    // publish offer
    // withdraw offer
    // bulk CRUD
}
