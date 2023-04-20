using Microsoft.AspNetCore.Authorization;

namespace ProductlineApp.WebUI.Services.Authorization;

public class JwtAuthorizationHandler : AuthorizationHandler<IAuthorizationRequirement>
{
    private readonly IAuthorizationManager _authorizationManager;

    public JwtAuthorizationHandler(IAuthorizationManager authorizationManager)
    {
        this._authorizationManager = authorizationManager;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
    {
        var result = await this._authorizationManager.AuthorizeAsync(context.User, context.Resource, context.Requirements);

        if (result.Succeeded)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}
