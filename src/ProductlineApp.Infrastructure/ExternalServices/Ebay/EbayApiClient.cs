using Newtonsoft.Json;
using ProductlineApp.Application.Common.Platforms.Ebay.ApiClient;
using ProductlineApp.Infrastructure.Configuration.Ebay;
using ProductlineApp.Shared.Models.Ebay;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Net.Http.Headers;

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
        this._restClient.AddDefaultHeader("Content-Language", ebayConfiguration.ContentLanguage);
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

    public async Task<string> CreateOffer(string accessToken, EbayCreateOrReplaceInventoryRequest requestBody)
    {
        throw new NotImplementedException();
    }

    public async Task<EbayOffersReponse> GetOffers(string accessToken)
    {
        throw new NotImplementedException();
    }

    public async Task WithdrawOffer(string accessToken, string offerId)
    {
        throw new NotImplementedException();
    }
}
