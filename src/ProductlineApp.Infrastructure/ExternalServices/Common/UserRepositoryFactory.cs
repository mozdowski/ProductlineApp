using Microsoft.Extensions.DependencyInjection;
using ProductlineApp.Domain.Aggregates.User.Repository;

namespace ProductlineApp.Infrastructure.ExternalServices.Common;

public interface IUserRepositoryFactory
{
    IUserRepository Create();
}

public class UserRepositoryFactory : IUserRepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public UserRepositoryFactory(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    public IUserRepository Create()
    {
        return this._serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IUserRepository>();
    }
}
