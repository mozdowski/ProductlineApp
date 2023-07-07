using ProductlineApp.Shared.Models.Allegro;

namespace ProductlineApp.Application.Common.Platforms.Allegro.ApiClient;

public interface IAllegroApiClient
{
    string GetAuthorizationUrl();

    Task<AllegroTokenResponse> GetAccessTokenAsync(string code);

    Task<AllegroTokenResponse> GetRefreshTokenAsync(string accessToken);

    Task<AllegroOrdersResponse> GetOrdersAsync(
        string accessToken,
        int offset = 0,
        int limit = 100,
        string status = null,
        string fulfillmentStatus = null,
        string lineItemSendingStatus = null,
        DateTime? boughtAtLte = null,
        DateTime? boughtAtGte = null,
        string paymentId = null,
        string surchargeId = null,
        string deliveryMethodId = null,
        string buyerLogin = null,
        string marketplaceId = null,
        DateTime? updatedAtLte = null,
        DateTime? updatedAtGte = null,
        string sort = null);

    Task<string> CreateListingAsync(string accessToken, AllegroCreateListingRequest requestBody);

    Task<IEnumerable<AllegroUserOffersResponse.Offer>> GetOffersAsync(
        string accessToken,
        string offerId = null,
        string name = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        List<string> publicationStatuses = null,
        List<string> sellingFormats = null,
        List<string> externalIds = null,
        string shippingRatesId = null,
        bool? shippingRatesIdEmpty = null,
        string sort = null,
        int limit = 20,
        int offset = 0,
        string categoryId = null,
        bool? productIdEmpty = null,
        bool? productizationRequired = null,
        bool? buyableOnlyByBusiness = null,
        string fundraisingCampaignId = null,
        bool? fundraisingCampaignIdEmpty = null);

    Task<AllegroCategoriesResponse> GetCategoriesAsync(string accessToken, string parentId = null);

    Task<AllegroProductCalalogueResponse> GetProductCatalogue(
        string accessToken,
        string phrase,
        string mode = null,
        string language = null,
        string categoryId = null,
        string dynamicFilter = null,
        string cursor = null,
        bool includeDrafts = false);

    Task<string> GetProductParametersForCategory(string accessToken, string categoryId);

    Task<AllegroCatalogueProductDetailsResponse> CatalogueProductDetails(string accessToken, string productId);
}
