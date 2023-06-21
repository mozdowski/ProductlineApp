using ProductlineApp.Application.User.DTO;

namespace ProductlineApp.Application.Authentication.DTO;

public record AuthenticationResult(
     Guid Id,
     string Username,
     string Email,
     string Token,
     string? Avatar);
