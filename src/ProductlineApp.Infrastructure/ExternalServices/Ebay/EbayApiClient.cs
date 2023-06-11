using Newtonsoft.Json.Linq;
using ProductlineApp.Application.Common.Platforms.Ebay.ApiClient;
using ProductlineApp.Infrastructure.Configuration.Ebay;
using ProductlineApp.Shared.Models.Ebay;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ProductlineApp.Infrastructure.ExternalServices.Ebay;

public class EbayApiClient : IEbayApiClient
{
    private readonly IEbayConfiguration _ebayConfiguration;
    private readonly RestClient _restClient;

    public EbayApiClient(
        IEbayConfiguration ebayConfiguration,
        HttpClient httpClient)
    {
        this._ebayConfiguration = ebayConfiguration;
        this._restClient = new RestClient(this._ebayConfiguration.BaseApiUrl);
        // this._restClient.AddDefaultHeader("Content-Language", ebayConfiguration.ContentLanguage);
    }

    public string GetAuthorizationUrl()
    {
        var uriBuilder = new UriBuilder(this._ebayConfiguration.AuthUri);
        var queryParams = new Dictionary<string, string>
        {
            { "client_id", this._ebayConfiguration.ClientId },
            { "response_type", "code" },
            { "redirect_uri", this._ebayConfiguration.RedirectUri },
            { "scope", this._ebayConfiguration.Scopes },
        };

        string queryString = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));

        uriBuilder.Query = queryString;

        return uriBuilder.ToString();
    }

    public async Task<EbayTokenResponse> GetAccessTokenAsync(string code)
    {
        var request = new RestRequest(this._ebayConfiguration.OAuth2TokenUri, Method.Post)
        {
            Authenticator = new HttpBasicAuthenticator(
                this._ebayConfiguration.ClientId,
                this._ebayConfiguration.ClientSecret),
        };

        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

        request.AddParameter("grant_type", "authorization_code");
        request.AddParameter("code", code);
        request.AddParameter("redirect_uri", this._ebayConfiguration.RedirectUri);

        var response = await this._restClient.ExecuteAsync<EbayTokenResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Failed to get token: {response.StatusCode} - {response.Content}");
        }

        return response.Data;
    }

    public async Task<EbayTokenResponse> GetRefreshTokenAsync(string refreshToken)
    {
        var request = new RestRequest(this._ebayConfiguration.OAuth2TokenUri, Method.Post)
        {
            Authenticator = new HttpBasicAuthenticator(
                this._ebayConfiguration.ClientId,
                this._ebayConfiguration.ClientSecret),
        };

        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        request.AddParameter("grant_type", "refresh_token");
        request.AddParameter("refresh_token", refreshToken);
        request.AddParameter("redirect_uri", this._ebayConfiguration.RedirectUri);

        var response = await this._restClient.ExecuteAsync<EbayTokenResponse>(request);

        if (response.StatusCode != HttpStatusCode.OK || response.Data is null)
        {
            throw new Exception($"Failed to refresh token: {response.StatusCode}");
        }

        return response.Data;
    }

    public async Task CreateOrReplaceInventoryItem(string accessToken, string sku, EbayCreateOrReplaceInventoryRequest requestBody)
    {
        var request = new RestRequest($"sell/inventory/v1/inventory_item/{sku}", Method.Put)
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);
        request.AddJsonBody(requestBody, ContentType.Json);

        var response = await this._restClient.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to create listing: {response.StatusCode} - {response.Content}");
        }
    }

    public async Task<EbayInventoryItems> GetInventoryItems(string accessToken, int? limit, int? offset)
    {
        throw new NotImplementedException();
    }

    public async Task<EbayInventoryLocations> GetInventoryLocations(string accessToken, int? offset, int? limit)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateOffer(string accessToken, EbayCreateOfferRequest requestBody)
    {
        var request = new RestRequest($"sell/inventory/v1/offer", Method.Post)
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);
        request.AddJsonBody(requestBody, ContentType.Json);

        var response = await this._restClient.ExecuteAsync<EbayCreateOfferResponse>(request);

        if (!response.IsSuccessful || response.Data is null)
        {
            throw new Exception($"Failed to create the offer: {response.StatusCode} - {response.Content}");
        }

        return response.Data.OfferId;
    }

    public async Task<IEnumerable<EbayOffersReponse.Offer>> GetOffers(string accessToken, IEnumerable<string> offerIds)
    {
        var tasks = offerIds.Select(offerId => this.GetOfferById(accessToken, offerId)).ToList();

        await Task.WhenAll(tasks);

        return (from task in tasks where task.Result is not null select task.Result).ToList();
    }

    // public async Task<IEnumerable<EbayOffersReponse.Offer>> GetOffers(string accessToken)
    // {
    //     List<string> allSkus = await this.GetInventorySkusAsync(accessToken);
    //
    //     return await this.GetOffers(accessToken, allSkus);
    // }

    public async Task WithdrawOffer(string accessToken, string offerId)
    {
        var request = new RestRequest($"sell/inventory/v1/offer/{offerId}/withdraw", Method.Post)
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };
        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        var response = await this._restClient.ExecuteAsync(request);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to withdraw the offer: {response.StatusCode} - {response.Content}");
        }
    }

    public async Task<string> PublishOffer(string accessToken, string offerId)
    {
        var request = new RestRequest($"sell/inventory/v1/offer/{offerId}/publish", Method.Post)
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        var response = await this._restClient.ExecuteAsync<EbayPublishOfferResponse>(request);

        if (!response.IsSuccessful || response.Data is null)
        {
            throw new Exception($"Failed to publish the offer: {response.StatusCode} - {response.Content}");
        }

        return response.Data.ListingId;
    }

    public async Task<EbaySuggestedCategoriesResponse> GetCategories(string accessToken, string phrase)
    {
        var defaultCategoryTreeId = await this.GetDefaultCategoryTreeId(accessToken);

        var request = new RestRequest($"commerce/taxonomy/v1/category_tree/{defaultCategoryTreeId}/get_category_suggestions?q={phrase}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        request.AddHeader("Accept-Encoding", "application/gzip");
        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        var response = await this._restClient.ExecuteAsync<EbaySuggestedCategoriesResponse>(request);

        if (!response.IsSuccessful || response.Data is null)
        {
            throw new Exception($"Failed to get categories: {response.StatusCode} - {response.Content}");
        }

        return response.Data;
    }

    public async Task<EbayCategoryTreeResponse> GetCategories(string accessToken)
    {
        var defaultCategoryTreeId = await this.GetDefaultCategoryTreeId(accessToken);

        var request = new RestRequest($"commerce/taxonomy/v1/category_tree/{defaultCategoryTreeId}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        request.AddHeader("Accept-Encoding", "application/gzip");
        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        var response = await this._restClient.ExecuteAsync<EbayCategoryTreeResponse>(request);

        if (!response.IsSuccessful || response.Data is null)
        {
            throw new Exception($"Failed to get categories: {response.StatusCode} - {response.Content}");
        }

        return response.Data;
    }

    public async Task<EbayAspectsResponse> GetAspectsForCategory(string accessToken, string categoryId)
    {
        var defaultCategoryTreeId = await this.GetDefaultCategoryTreeId(accessToken);

        var request = new RestRequest($"commerce/taxonomy/v1/category_tree/{defaultCategoryTreeId}/get_item_aspects_for_category?category_id={categoryId}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };
        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        var response = await this._restClient.ExecuteAsync<EbayAspectsResponse>(request);

        if (!response.IsSuccessful || response.Data is null)
        {
            throw new Exception($"Failed to get aspects for category {categoryId}: {response.StatusCode} - {response.Content}");
        }

        return response.Data;
    }

    public async Task<string> GetCategoryNameById(string accessToken, string categoryId)
    {
        var defaultCategoryTreeId = await this.GetDefaultCategoryTreeId(accessToken);

        var request = new RestRequest($"commerce/taxonomy/v1/category_tree/{defaultCategoryTreeId}/get_category_subtree?category_id={categoryId}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };
        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        var response = await this._restClient.ExecuteAsync(request);

        if (!response.IsSuccessful || response.Content is null)
        {
            throw new Exception($"Failed to get category root id: {response.StatusCode} - {response.Content}");
        }

        var jsonResponse = JObject.Parse(response.Content);

        return jsonResponse["categorySubtreeNode"]?["category"]?["categoryName"]?.ToString() ?? string.Empty;
    }

    public async Task<IEnumerable<EbayOrderResponse>> GetOrders(string accessToken, IEnumerable<string> orderIds)
    {
        // bool hasMore = true;
        // string endpointUrl = $"sell/fulfillment/v1/order?orderIds" + string.Join(",", orderIds);
        // var orders = new List<EbayOrderResponse>();
        //
        // while (hasMore)
        // {
        //     var request = new RestRequest(endpointUrl)
        //     {
        //         Authenticator = new JwtAuthenticator(accessToken),
        //     };
        //
        //     var response = await this._restClient.ExecuteAsync<EbayOrdersResponse>(request);
        //
        //     if (!response.IsSuccessful || response.Data is null)
        //     {
        //         throw new Exception($"Failed to get orders: {response.StatusCode} - {response.Content}");
        //     }
        //
        //     orders.AddRange(response.Data.Orders);
        //
        //     if (response.Data.Next is not null)
        //     {
        //         endpointUrl = response.Data.Next;
        //     }
        //     else
        //     {
        //         hasMore = false;
        //     }
        // }
        //
        // return orders;

        string json = await File.ReadAllTextAsync("../../Mocks/ebay_orders.json");
        var response = JsonConvert.DeserializeObject<EbayOrdersResponse>(json);

        return response.Orders;
    }

    public async Task<IEnumerable<EbayLocationsResponse.LocationItem>> GetMerchantLocationKeys(string accessToken)
    {
        bool hasMore = true;
        string endpointUrl = $"sell/inventory/v1/location";
        var locations = new List<EbayLocationsResponse.LocationItem>();

        while (hasMore)
        {
            var request = new RestRequest(endpointUrl)
            {
                Authenticator = new JwtAuthenticator(accessToken),
            };

            var response = await this._restClient.ExecuteAsync<EbayLocationsResponse>(request);

            if (!response.IsSuccessful || response.Data is null)
            {
                throw new Exception($"Failed to get orders: {response.StatusCode} - {response.Content}");
            }

            locations.AddRange(response.Data.Locations);

            if (response.Data.Next is not null)
            {
                endpointUrl = response.Data.Next;
            }
            else
            {
                hasMore = false;
            }
        }

        return locations;
    }

    private async Task<string> GetDefaultCategoryTreeId(string accessToken)
    {
        var request = new RestRequest($"commerce/taxonomy/v1/get_default_category_tree_id?marketplace_id={this._ebayConfiguration.MarketplaceId}")
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };
        request.AddHeader("Content-Language", this._ebayConfiguration.ContentLanguage);

        var response = await this._restClient.ExecuteAsync<EbayDefaultCategoryTreeIdResponse>(request);

        if (!response.IsSuccessful || response.Data is null)
        {
            throw new Exception($"Failed to get category root id: {response.StatusCode} - {response.Content}");
        }

        return response.Data.CategoryTreeId;
    }

    private async Task<EbayOffersReponse.Offer?> GetOfferById(string accessToken, string offerId)
    {
        string endpointUrl = $"sell/inventory/v1/offer/{offerId}";

        var request = new RestRequest(endpointUrl)
        {
            Authenticator = new JwtAuthenticator(accessToken),
        };

        var response = await this._restClient.ExecuteAsync<EbayOffersReponse.Offer>(request);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        if (!response.IsSuccessful || response.Data is null)
        {
            throw new Exception($"Failed to get offers for offer id {offerId}: {response.StatusCode} - {response.Content}");
        }

        var offer = response.Data;
        offer.CategoryName = await this.GetCategoryNameById(accessToken, offer.CategoryId);

        return offer;
    }

    private async Task<List<EbayOffersReponse.Offer>> GetOffersBySku(string accessToken, string sku)
    {
        bool hasMore = true;
        string endpointUrl = $"sell/inventory/v1/offer/?sku={sku}";
        var offers = new List<EbayOffersReponse.Offer>();

        while (hasMore)
        {
            var request = new RestRequest(endpointUrl)
            {
                Authenticator = new JwtAuthenticator(accessToken),
            };

            var response = await this._restClient.ExecuteAsync<EbayOffersReponse>(request);

            if (!response.IsSuccessful || response.Data is null)
            {
                throw new Exception($"Failed to get offers for offer id {sku}: {response.StatusCode} - {response.Content}");
            }

            offers.AddRange(response.Data.Offers);

            if (response.Data.Next is not null)
            {
                endpointUrl = response.Data.Next;
            }
            else
            {
                hasMore = false;
            }
        }

        foreach (var offer in offers)
        {
            offer.CategoryName = await this.GetCategoryNameById(accessToken, offer.CategoryId);
        }

        return offers;
    }

    private async Task<List<string>> GetInventorySkusAsync(string accessToken)
    {
        bool hasMore = true;
        const string basicEndpoint = "sell/inventory/v1/inventory_item";
        string queryParams = $"/?limit=10&offset=0";
        var skus = new List<string>();

        while (hasMore)
        {
            var request = new RestRequest(basicEndpoint + queryParams)
            {
                Authenticator = new JwtAuthenticator(accessToken),
            };

            var response = await this._restClient.ExecuteAsync<EbayInventoryItems>(request);

            if (!response.IsSuccessful || response.Data is null)
            {
                throw new Exception($"Failed to get inventory skus: {response.StatusCode} - {response.Content}");
            }

            skus.AddRange(response.Data.InventoryItems.Select(x => x.Sku));

            if (response.Data.Next is not null)
            {
                queryParams = response.Data.Next;
            }
            else
            {
                hasMore = false;
            }
        }

        return skus;
    }
}
