namespace ProductlineApp.Infrastructure.Configuration.Allegro;

public interface IAllegroConfiguration
{
    string ClientId { get; }

    string ClientSecret { get; }

    string RedirectUri { get; }

    string AuthUri { get; }

    string OAuth2TokenUri { get; }

    string BaseApiUrl { get; }
}
