namespace ProductlineApp.Infrastructure.Configuration.Allegro;

public class AllegroConfiguration : IAllegroConfiguration
{
    public string ClientId { get; }

    public string ClientSecret { get; }

    public string RedirectUri { get; }

    public string AuthUri { get; }

    public string OAuth2TokenUri { get; }

    public string BaseApiUrl { get; }

    public string BaseRestApiUrl { get; }
}
