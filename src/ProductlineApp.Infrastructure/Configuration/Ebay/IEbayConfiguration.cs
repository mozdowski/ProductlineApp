namespace ProductlineApp.Infrastructure.Configuration.Ebay;

public interface IEbayConfiguration
{
    string ClientId { get; }

    string ClientSecret { get; }

    string RedirectUri { get; }

    string AuthUri { get; }

    string OAuth2TokenUri { get; }

    string Scopes { get; }

    string BaseApiUrl { get; }
}
