using Newtonsoft.Json;
using ProductlineApp.Infrastructure.Configuration.Amazon;
using ProductlineApp.Infrastructure.Models;
using ProductlineApp.Infrastructure.Models.Amazon;

namespace ProductlineApp.Infrastructure.ExternalServices.Amazon;

public class AmazonApiClient : IAmazonApiClient
{
    private readonly IAmazonConfiguration _amazonConfiguration;
    private readonly HttpClient _httpClient;

    public AmazonApiClient(
        IAmazonConfiguration amazonConfiguration,
        HttpClient httpClient)
    {
        this._amazonConfiguration = amazonConfiguration;
        this._httpClient = httpClient;
    }

    public Task<string> GetAuthorizationUrlAsync()
    {
        var uriBuilder = new UriBuilder(this._amazonConfiguration.AuthUri);
        var queryParams = new Dictionary<string, string>
        {
            { "client_id", this._amazonConfiguration.ClientId },
            { "scope", this._amazonConfiguration.Scopes },
            { "response_type", "code" },
            { "redirect_uri", this._amazonConfiguration.RedirectUri },
        };

        string queryString = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));

        uriBuilder.Query = queryString;

        return new Task<string>(uriBuilder.ToString);
    }

    public async Task<AmazonTokenResponse> GetAccessTokenAsync(string code)
    {
        var uriBuilder = new UriBuilder(this._amazonConfiguration.OAuth2TokenUri);
        var queryParams = new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", code },
            { "redirect_uri", this._amazonConfiguration.RedirectUri },
            { "client_id", this._amazonConfiguration.ClientId },
            { "client_secret", this._amazonConfiguration.ClientSecret },
        };
        var queryString = string.Join("&", queryParams.Select(p => $"{p.Key}={p.Value}"));

        uriBuilder.Query = queryString;

        var response = await this._httpClient.PostAsync(uriBuilder.ToString(), null);
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<AmazonTokenResponse>(responseContent);
    }
}
