using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.WebUI.Services.Authorization;

public class JwtAuthorizationManager : IAuthorizationManager, ICurrentUserContext
{
    private readonly IConfiguration _configuration;
    private Guid _userId;

    public JwtAuthorizationManager(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public Guid UserId => this._userId;

    public IDictionary<PlatformNames, UserToken> PlatformTokens { get; set; }

    Guid ICurrentUserContext.UserId => this._userId;

    public async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
    {
        if (user == null || !user.Identity.IsAuthenticated)
        {
            return AuthorizationResult.Failed();
        }

        var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out this._userId))
        {
            return AuthorizationResult.Failed();
        }

        // Check if the user is authorized based on the requirements.
        // ...

        return AuthorizationResult.Success();
    }

    public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object? resource, string policyName)
    {
        throw new NotImplementedException();
    }

    private bool IsAuthorized(IEnumerable<IAuthorizationRequirement> requirements)
    {
        // Perform authorization checks based on the requirements and the user ID.
        // ...

        return true;
    }
}
