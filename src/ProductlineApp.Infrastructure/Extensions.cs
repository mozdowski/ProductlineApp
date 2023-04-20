﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Application.Common.Platforms.Allegro.ApiClient;
using ProductlineApp.Application.Common.Platforms.Allegro.Services;
using ProductlineApp.Application.Common.Platforms.Ebay.ApiClient;
using ProductlineApp.Application.Common.Platforms.Ebay.Services;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Application.Security;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Products.Repository;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Infrastructure.Authentication;
using ProductlineApp.Infrastructure.Configuration.Allegro;
using ProductlineApp.Infrastructure.Configuration.Ebay;
using ProductlineApp.Infrastructure.ExternalServices;
using ProductlineApp.Infrastructure.ExternalServices.Allegro;
using ProductlineApp.Infrastructure.ExternalServices.Common;
using ProductlineApp.Infrastructure.ExternalServices.Ebay;
using ProductlineApp.Infrastructure.Persistance;
using ProductlineApp.Infrastructure.Persistance.Repositories;
using ProductlineApp.Infrastructure.Security;
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
            services.AddAuth(configuration)
                    .AddPersistance(configuration);

            services.AddScoped<HttpClient>();
            services.AddSingleton<IUploadFileService, UploadFileService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.Configure<EbayConfiguration>(configuration.GetSection($"Infrastructure:Platforms:EbayConfiguration"));
            services.AddSingleton<IEbayConfiguration>(
                sp => sp.GetRequiredService<IOptions<EbayConfiguration>>().Value);

            services.Configure<AllegroConfiguration>(configuration.GetSection($"Infrastructure:Platforms:AllegroConfiguration"));
            services.AddSingleton<IAllegroConfiguration>(
                sp => sp.GetRequiredService<IOptions<AllegroConfiguration>>().Value);

            services.AddScoped<IEbayApiClient, EbayApiClient>();
            services.AddScoped<IAllegroApiClient, AllegroApiClient>();

            // services.AddScoped(async serviceProvider =>
            // {
            //     var allegroApiClient = serviceProvider.GetService<IAllegroApiClient>();
            //     var mapper = serviceProvider.GetService<IMapper>();
            //     var mediator = serviceProvider.GetService<IMediator>();
            //     var currentUser = serviceProvider.GetService<ICurrentUserContext>();
            //     var platformRepository = serviceProvider.GetService<IPlatformRepository>();
            //
            //     return await AllegroService.CreateAsync(
            //         allegroApiClient,
            //         mapper,
            //         mediator,
            //         currentUser,
            //         platformRepository);
            // });
            // services.AddScoped(async serviceProvider =>
            // {
            //     var ebayApiClient = serviceProvider.GetService<IEbayApiClient>();
            //     var mapper = serviceProvider.GetService<IMapper>();
            //     var mediator = serviceProvider.GetService<IMediator>();
            //     var currentUser = serviceProvider.GetService<ICurrentUserContext>();
            //     var platformRepository = serviceProvider.GetService<IPlatformRepository>();
            //
            //     return await EbayService.CreateAsync(
            //         ebayApiClient,
            //         mapper,
            //         mediator,
            //         currentUser,
            //         platformRepository);
            // });

            services.AddScoped<IEbayService, EbayService>();
            services.AddScoped<IAllegroService, AllegroService>();
            services.AddScoped<IPlatformService, AllegroService>();
            services.AddScoped<IPlatformService, EbayService>();

            services.AddScoped<IPlatformServiceDispatcher>(provider =>
            {
                var platformServices = provider.GetServices<IPlatformService>();
                return new PlatformServiceDispatcher(platformServices, provider);
            });

            // services.AddScoped<IEnumerable<IPlatformService>>(p => p.GetServices<IPlatformService>());
            // services.AddScoped<IPlatformServiceDispatcher, PlatformServiceDispatcher>();

            // services.AddScoped<IPlatformService>(provider =>
            // {
            //     var allegroService = provider.GetService<IAllegroService>();
            //     var ebayService = provider.GetService<IEbayService>();
            //     return new List<IPlatformService> { allegroService, ebayService };
            // });
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

            // services.AddSingleton(configuration);
            //
            // services.AddDbContext<ProductlineDbContext>(options =>
            //     options.UseNpgsql("Server=productline-db.postgres.database.azure.com;Database=postgres;Port=5432;User Id=productline_admin;Password=Inzynierka*12;Ssl Mode=Require;"));

            // services.AddDbContext<ProductlineDbContext>();

            // services.AddScoped<IUserRepository, UserRepository>();

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

            // services.AddAuthorization(options =>
            // {
            //     options.DefaultPolicy = new AuthorizationPolicyBuilder()
            //         .AddRequirements(new DenyAnonymousAuthorizationRequirement())
            //         .Build();
            //
            //     options.AddPolicy("MyPolicy", policy =>
            //     {
            //         policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            //         policy.RequireAuthenticatedUser();
            //         policy.Requirements.Add(new MyRequirement());
            //     });
            // });

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

        private static IServiceCollection AddPersistance(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProductlineDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("postgres")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IListingRepository, ListingRepository>();

            return services;
        }
    }
}
