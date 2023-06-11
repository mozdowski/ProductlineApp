using Microsoft.AspNetCore.Authorization;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.WebUI.Services.Authorization;

namespace ProductlineApp.WebUI
{
    public static class Extensions
    {
        public static IServiceCollection AddWebUI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthorizationManager, JwtAuthorizationManager>();

            // services.AddSingleton<JwtAuthorizationManager>();
            services.AddScoped<IAuthorizationHandler, JwtAuthorizationHandler>();

            services.AddScoped<ICurrentUserContext>(sp =>
            {
                var authManager = sp.GetRequiredService<IAuthorizationManager>();
                return (ICurrentUserContext)authManager;
            });

            return services;
        }
    }
}
