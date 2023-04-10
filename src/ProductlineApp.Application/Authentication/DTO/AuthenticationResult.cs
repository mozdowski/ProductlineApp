namespace ProductlineApp.Application.Authentication.DTO;

public record AuthenticationResult(
     Domain.Aggregates.User.User User,
     string Token);
