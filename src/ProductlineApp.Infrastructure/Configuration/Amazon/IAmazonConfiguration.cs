namespace ProductlineApp.Infrastructure.Configuration.Amazon;

public interface IAmazonConfiguration
{
    string ClientId { get; }

    string ClientSecret { get; }

    string RedirectUri { get; }

    string Scopes { get; }

    string AuthUri { get; }

    string OAuth2TokenUri { get; }
}
