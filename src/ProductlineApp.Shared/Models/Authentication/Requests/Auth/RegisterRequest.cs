using Microsoft.AspNetCore.Http;

namespace ProductlineApp.Shared.Models.Authentication.Requests.Auth;

public record RegisterRequest(string Username, string Email, string Password, IFormFile? Avatar);
