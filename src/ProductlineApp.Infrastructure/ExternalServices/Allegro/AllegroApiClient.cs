using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductlineApp.Application.Common.Platforms.Allegro.ApiClient;
using ProductlineApp.Infrastructure.Configuration.Allegro;
using ProductlineApp.Shared.Models.Allegro;
using RestSharp;
using RestSharp.Authenticators;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using Method = RestSharp.Method;

namespace ProductlineApp.Infrastructure.ExternalServices.Allegro;

public class AllegroApiClient : IAllegroApiClient
{
    private readonly IAllegroConfiguration _allegroConfiguration;
    private readonly HttpClient _httpClient;
    private readonly RestClient _restClient;

    public AllegroApiClient(
        IAllegroConfiguration allegroConfiguration,
        HttpClient httpClient)
    {
        this._allegroConfiguration = allegroConfiguration;
        this._httpClient = httpClient;
        this._restClient = new RestClient(this._allegroConfiguration.BaseApiUrl);
        this._restClient.AddDefaultHeader("Accept", "application/vnd.allegro.public.v1+json");
    }

    public string GetAuthorizationUrl()
    {
        var uriBuilder = new UriBuilder(this._allegroConfiguration.AuthUri);
        var queryParams = new Dictionary<string, string>
        {
            { "client_id", this._allegroConfiguration.ClientId },
            { "response_type", "code" },
            { "redirect_uri", this._allegroConfiguration.RedirectUri },
        };

        string queryString = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));

        uriBuilder.Query = queryString;

        return uriBuilder.ToString();
    }

    public async Task<AllegroTokenResponse> GetAccessTokenAsync(string code)
    {
        var authHeader = new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(
                    $"{this._allegroConfiguration.ClientId}:{this._allegroConfiguration.ClientSecret}")));

        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("redirect_uri", this._allegroConfiguration.RedirectUri),
        });

        this._httpClient.DefaultRequestHeaders.Authorization = authHeader;
        var response = await this._httpClient.PostAsync(this._allegroConfiguration.OAuth2TokenUri, requestContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to get token: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AllegroTokenResponse>(responseContent);
    }

    public async Task<AllegroTokenResponse> GetRefreshTokenAsync(string refreshToken)
    {
        var authHeader = new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(
                    $"{this._allegroConfiguration.ClientId}:{this._allegroConfiguration.ClientSecret}")));

        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "refresh_token"),
            new KeyValuePair<string, string>("refresh_token", refreshToken),
            new KeyValuePair<string, string>("redirect_uri", this._allegroConfiguration.RedirectUri),
        });

        this._httpClient.DefaultRequestHeaders.Authorization = authHeader;
        var response = await this._httpClient.PostAsync(this._allegroConfiguration.OAuth2TokenUri, requestContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to refresh token: {response.StatusCode}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AllegroTokenResponse>(responseContent);
    }

    public async Task<AllegroOrdersResponse> GetOrdersAsync(string accessToken, int offset = 0, int limit = 100, string status = null, string fulfillmentStatus = null,
        string lineItemSendingStatus = null, DateTime? boughtAtLte = null, DateTime? boughtAtGte = null,
        string paymentId = null, string surchargeId = null, string deliveryMethodId = null, string buyerLogin = null,
        string marketplaceId = null, DateTime? updatedAtLte = null, DateTime? updatedAtGte = null, string sort = null)
    {
        var request = new RestRequest("order/checkout-forms");

        request.AddParameter("offset", offset);
        request.AddParameter("limit", limit);

        if (!string.IsNullOrEmpty(status))
        {
            request.AddParameter("status", status);
        }

        if (!string.IsNullOrEmpty(fulfillmentStatus))
        {
            request.AddParameter("fulfillment.status", fulfillmentStatus);
        }

        if (!string.IsNullOrEmpty(lineItemSendingStatus))
        {
            request.AddParameter("fulfillment.shipmentSummary.lineItemsSent", lineItemSendingStatus);
        }

        if (boughtAtLte.HasValue)
        {
            request.AddParameter("lineItems.boughtAt.lte", boughtAtLte.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }

        if (boughtAtGte.HasValue)
        {
            request.AddParameter("lineItems.boughtAt.gte", boughtAtGte.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }

        if (!string.IsNullOrEmpty(paymentId))
        {
            request.AddParameter("payment.id", paymentId);
        }

        if (!string.IsNullOrEmpty(surchargeId))
        {
            request.AddParameter("surcharges.id", surchargeId);
        }

        if (!string.IsNullOrEmpty(deliveryMethodId))
        {
            request.AddParameter("delivery.method.id", deliveryMethodId);
        }

        if (!string.IsNullOrEmpty(buyerLogin))
        {
            request.AddParameter("buyer.login", buyerLogin);
        }

        if (!string.IsNullOrEmpty(marketplaceId))
        {
            request.AddParameter("marketplace.id", marketplaceId);
        }

        if (updatedAtLte.HasValue)
        {
            request.AddParameter("updatedAt.lte", updatedAtLte.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }

        if (updatedAtGte.HasValue)
        {
            request.AddParameter("updatedAt.gte", updatedAtGte.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }

        if (!string.IsNullOrEmpty(sort))
        {
            request.AddParameter("sort", sort);
        }

        request.Authenticator = new JwtAuthenticator(accessToken);

        var response = await this._restClient.ExecuteAsync<AllegroOrdersResponse>(request);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error calling Allegro API: {response.StatusCode} {response.ErrorMessage}");
        }

        return response.Data;
    }

    public async Task<string> CreateListingAsync(string accessToken, AllegroCreateListingRequest requestBody)
    {
        var request = new RestRequest("/sale/product-offers", Method.Post)
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        request.AddJsonBody(requestBody, "application/vnd.allegro.public.v1+json");

        var response = await this._restClient.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to create listing: {response.StatusCode} - {response.Content}");
        }

        var createdListingId = JObject.Parse(response.Content)["id"].ToString();
        return createdListingId;
    }

    public async Task<IEnumerable<AllegroUserOffersResponse.Offer>> GetOffersAsync(string accessToken, string offerId = null, string name = null, decimal? minPrice = null,
        decimal? maxPrice = null, List<string>? publicationStatuses = null, List<string>? sellingFormats = null, List<string>? externalIds = null,
        string shippingRatesId = null, bool? shippingRatesIdEmpty = null, string sort = null, int limit = 20,
        int offset = 0, string categoryId = null, bool? productIdEmpty = null, bool? productizationRequired = null,
        bool? buyableOnlyByBusiness = null, string fundraisingCampaignId = null, bool? fundraisingCampaignIdEmpty = null)
    {
        var request = new RestRequest("sale/offers")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        request.AddParameter("limit", limit.ToString());
        request.AddParameter("offset", offset.ToString());

        if (!string.IsNullOrEmpty(offerId))
            request.AddParameter("offer.id", offerId);
        if (!string.IsNullOrEmpty(name))
            request.AddParameter("name", name);
        if (minPrice.HasValue)
            request.AddParameter("sellingMode.price.amount.gte", minPrice.Value.ToString(CultureInfo.InvariantCulture));
        if (maxPrice.HasValue)
            request.AddParameter("sellingMode.price.amount.lte", maxPrice.Value.ToString(CultureInfo.InvariantCulture));
        if (publicationStatuses != null && publicationStatuses.Any())
            publicationStatuses.ForEach(s => request.AddParameter("publication.status", s));
        if (sellingFormats != null && sellingFormats.Any())
            sellingFormats.ForEach(s => request.AddParameter("sellingMode.format", s));
        if (externalIds != null && externalIds.Any())
            externalIds.ForEach(id => request.AddParameter("external.id", id));
        if (!string.IsNullOrEmpty(shippingRatesId))
            request.AddParameter("delivery.shippingRates.id", shippingRatesId);
        if (shippingRatesIdEmpty.HasValue)
            request.AddParameter("delivery.shippingRates.id.empty", shippingRatesIdEmpty.Value.ToString());
        if (!string.IsNullOrEmpty(sort))
            request.AddParameter("sort", sort);
        if (!string.IsNullOrEmpty(categoryId))
            request.AddParameter("category.id", categoryId);
        if (productIdEmpty.HasValue)
            request.AddParameter("product.id.empty", productIdEmpty.Value.ToString());
        if (productizationRequired.HasValue)
            request.AddParameter("productizationRequired", productizationRequired.Value.ToString());
        if (buyableOnlyByBusiness.HasValue)
            request.AddParameter("b2b.buyableOnlyByBusiness", buyableOnlyByBusiness.Value.ToString());
        if (!string.IsNullOrEmpty(fundraisingCampaignId))
            request.AddParameter("fundraisingCampaign.id", fundraisingCampaignId);
        if (fundraisingCampaignIdEmpty.HasValue)
            request.AddParameter("fundraisingCampaign.id.empty", fundraisingCampaignIdEmpty.Value.ToString());

        var response = await this._restClient.ExecuteAsync<AllegroUserOffersResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get seller offers: {response.StatusCode}");
        }

        var offers = response.Data.Offers;

        var tasks = offers.Select(async offer =>
        {
            string categoryName = await this.GetCategoryNameById(accessToken, offer.Category.Id);
            string description = await this.GetOfferDescription(accessToken, offer.Id);

            offer.Category.Name = categoryName;
            offer.Description = description;
        }).ToList();

        await Task.WhenAll(tasks);

        return offers;
    }

    public async Task<AllegroCategoriesResponse> GetCategoriesAsync(string accessToken, string parentId = null)
    {
        var request = new RestRequest("sale/categories")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        if (!string.IsNullOrEmpty(parentId)) request.AddParameter("parent.id", parentId);

        var response = await this._restClient.ExecuteAsync<AllegroCategoriesResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get categories list: {response.StatusCode}");
        }

        return response.Data;
    }

    public async Task<AllegroProductCalalogueResponse> GetProductCatalogue(string accessToken, string phrase, string mode = null, string language = null,
        string categoryId = null, string dynamicFilter = null, string cursor = null, bool includeDrafts = false)
    {
        var request = new RestRequest("sale/products")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        request.AddParameter("phrase", phrase);
        request.AddParameter("includeDrafts", includeDrafts);

        if (!string.IsNullOrEmpty(mode))
        {
            request.AddParameter("mode", mode);
        }

        if (!string.IsNullOrEmpty(language))
        {
            request.AddParameter("language", language);
        }

        if (!string.IsNullOrEmpty(categoryId))
        {
            request.AddParameter("category.id", categoryId);
        }

        if (!string.IsNullOrEmpty(dynamicFilter))
        {
            request.AddParameter(dynamicFilter, string.Empty);
        }

        if (!string.IsNullOrEmpty(cursor))
        {
            request.AddParameter("page.id", cursor);
        }

        var response = await this._restClient.ExecuteAsync<AllegroProductCalalogueResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get product catalogue: {response.StatusCode}");
        }

        return response.Data;
    }

    public async Task<string> GetProductParametersForCategory(string accessToken, string categoryId)
    {
        var request = new RestRequest($"sale/categories/{categoryId}/product-parameters")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        var response = await this._restClient.ExecuteAsync<AllegroProductParametersResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get parameters list: {response.StatusCode}");
        }

        return response.Content;
    }

    public async Task<AllegroCatalogueProductDetailsResponse> CatalogueProductDetails(string accessToken, string productId)
    {
        var request = new RestRequest($"sale/products/{productId}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        var response = await this._restClient.ExecuteAsync<AllegroCatalogueProductDetailsResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get parameters list: {response.StatusCode}");
        }

        return response.Data;
    }

    private async Task<string> GetCategoryNameById(string accessToken, string categoryId)
    {
        var request = new RestRequest($"sale/categories/{categoryId}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        var response = await this._restClient.ExecuteAsync<AllegroCategoryDetailsResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK || response.Data.Id != categoryId)
        {
            throw new Exception($"Failed to get category name: {response.StatusCode}");
        }

        return response.Data.Name;
    }

    private async Task<string> GetOfferDescription(string accessToken, string offerId)
    {
        var request = new RestRequest($"sale/product-offers/{offerId}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        var response = await this._restClient.ExecuteAsync<AllegroOfferDetailsResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get offer description: {response.StatusCode}");
        }

        var textDescriptionContent = string.Join(" ", response.Data.Description.Sections
            .SelectMany(section => section.Items)
            .Where(item => item.Type == "TEXT")
            .Select(item => item.Content));

        return textDescriptionContent;
    }
}
