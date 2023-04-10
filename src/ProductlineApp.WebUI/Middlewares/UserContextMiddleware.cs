using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.WebUI.Services.Authorization;

namespace ProductlineApp.WebUI.Middlewares;

public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task InvokeAsync(HttpContext context, ICurrentUserContext userContext, IUserService userService)
    {
        var userId = userContext.UserId;

        userContext.PlatformTokens = await userService.GetPlatformTokens(userId);

        await this._next(context);
    }
}
