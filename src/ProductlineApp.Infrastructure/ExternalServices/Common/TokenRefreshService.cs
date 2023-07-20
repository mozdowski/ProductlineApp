using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Domain.Aggregates.User.Repository;

namespace ProductlineApp.Infrastructure.ExternalServices.Common;

public class TokenRefreshService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<TokenRefreshService> _logger;
    private readonly Timer _timer;

    public TokenRefreshService(
        IServiceProvider serviceProvider,
        ILogger<TokenRefreshService> logger)
    {
        this._serviceProvider = serviceProvider;
        this._logger = logger;
        this._timer = new Timer(this.RefreshToken, null, TimeSpan.Zero, TimeSpan.FromMinutes(20));
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        this._logger.LogInformation("Token refresh service is starting.");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        this._logger.LogInformation("Token refresh service is stopping.");

        this._timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    private async void RefreshToken(object? state)
    {
        using var scope = this._serviceProvider.CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var platformServiceDispatcher = scope.ServiceProvider.GetRequiredService<IPlatformServiceDispatcher>();
        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

        var pageSize = configuration.GetValue<int>("Infrastructure:Platforms:Common:RefreshingTokenUserFetchingBatch");
        var pageNumber = 0;

        try
        {
            while (true)
            {
                var users = await userRepository.GetUsersBatchAsync(pageNumber, pageSize);

                if (!users.Any()) break;

                foreach (var user in users)
                {
                    var pcs = user.GetPlatformConnectionsToRefresh();

                    foreach (var pc in pcs)
                    {
                        var platformService = platformServiceDispatcher.Dispatch(pc.PlatformId.Value);
                        await platformService.RefreshAccessTokenAsync(user.Id, pc.RefreshToken);
                        this._logger.LogInformation($"Access token for user ID: {user.Id} and platformId: {pc.PlatformId} has been refreshed.");
                    }
                }

                pageNumber++;
            }
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, "An error occurred while refreshing the access token.");
        }
    }
}
