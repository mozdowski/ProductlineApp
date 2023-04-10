namespace ProductlineApp.Infrastructure.Configuration.Ebay;

public class EbayConfiguration : IEbayConfiguration
{
    public string ClientId { get; }

    public string ClientSecret { get; }

    public string RedirectUri { get; }

    public string AuthUri { get; }

    public string OAuth2TokenUri { get; }

    public string Scopes { get; }

    public string BaseApiUrl { get; }
}
