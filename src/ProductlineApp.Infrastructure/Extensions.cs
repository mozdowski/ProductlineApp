using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductlineApp.Application.Authentication.Queries;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Platforms.Allegro.Services;
using ProductlineApp.Infrastructure.Authentication;
using ProductlineApp.Infrastructure.Configuration.Allegro;
using ProductlineApp.Shared.Enums;
using System.Text;

namespace ProductlineApp.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // IApplicationDbContext
            // configuration = new ConfigurationBuilder()
            //     .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
            //     .Build();
            services.Configure<AllegroConfiguration>(configuration.GetSection(nameof(AllegroConfiguration)));
            services.AddSingleton<IAllegroConfiguration>(
                sp => sp.GetRequiredService<IOptions<AllegroConfiguration>>().Value);

            services.AddScoped<IAllegroApiService, AllegroApiService>();
            // services.AddScoped<AllegroApiService>(provider =>
            // {
            //     var currentUserContext = provider.GetRequiredService<ICurrentUserContext>();
            //     var mediator = provider.GetRequiredService<IMediator>();
            //     var query = new GetUserPlatformTokenByServiceNameQuery.Query(
            //         currentUserContext.UserId,
            //         PlatformNames.ALLEGRO);
            //     var accessToken = await mediator.Send(query);
            //     return new AllegroApiService(accessToken: accessToken);
            // });

            services.AddAuth(configuration);

            services.AddSingleton(configuration);

            return services;
        }

        private static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                });

            return services;
        }
    }
}
