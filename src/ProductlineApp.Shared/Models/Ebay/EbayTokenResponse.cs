using Newtonsoft.Json;

namespace ProductlineApp.Shared.Models.Ebay;

public class EbayTokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonProperty("refresh_token_expires_in")]
    public string RefreshTokenExpiresIn { get; set; }
}
