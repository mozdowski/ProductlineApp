namespace ProductlineApp.Infrastructure.Configuration.Allegro;

public class AllegroConfiguration : IAllegroConfiguration
{
    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string RedirectUri { get; set; }

    public string AuthUri { get; set; }

    public string OAuth2TokenUri { get; set; }

    public string BaseApiUrl { get; set; }

    public string BaseRestApiUrl { get; set; }
}
