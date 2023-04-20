namespace ProductlineApp.Application.Authentication.DTO;

public record UserToken(string AccessToken, string RefreshToken, DateTime ExpirationDate);
