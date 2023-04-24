namespace ProductlineApp.Infrastructure.Configuration.Ebay;

public interface IEbayConfiguration
{
    string ClientId { get; set; }

    string ClientSecret { get; set; }

    string RedirectUri { get; set; }

    string AuthUri { get; set; }

    string OAuth2TokenUri { get; set; }

    string Scopes { get; set; }

    string BaseApiUrl { get; set; }

    string ContentLanguage { get; set; }
}
