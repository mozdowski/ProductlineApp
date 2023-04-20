using System.Text.Json.Serialization;

namespace ProductlineApp.Shared.Models.Ebay;

public class EbayTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("refresh_token_expires_in")]
    public int RefreshTokenExpiresIn { get; set; }
}
