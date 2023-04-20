using Newtonsoft.Json;

namespace ProductlineApp.Infrastructure.Configuration.Ebay;

public class EbayConfiguration : IEbayConfiguration
{
    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string RedirectUri { get; set; }

    public string AuthUri { get; set; }

    public string OAuth2TokenUri { get; set; }

    public string Scopes { get; set; }

    public string BaseApiUrl { get; set; }
}
