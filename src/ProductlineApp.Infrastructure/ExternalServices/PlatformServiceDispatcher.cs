using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.ExternalServices;

public class PlatformServiceDispatcher : IPlatformServiceDispatcher
{
    private readonly IDictionary<PlatformId, Type> _serviceTypes;
    private readonly IServiceProvider _serviceProvider;

    public PlatformServiceDispatcher(
        IEnumerable<IPlatformService> services,
        IServiceProvider serviceProvider)
    {
        this._serviceTypes = services.ToDictionary(s => s.PlatformId, s => s.GetType());
        this._serviceProvider = serviceProvider;
    }

    public IPlatformService Dispatch(Guid platformId)
    {
        var platformIdValueObject = PlatformId.Create(platformId);

        if (!this._serviceTypes.TryGetValue(platformIdValueObject, out var serviceType))
        {
            throw new ArgumentException($"No service found for platform ID: {platformId}");
        }

        var iServiceType = serviceType.GetInterfaces().First(x => x != typeof(IPlatformService));

        return (IPlatformService)this._serviceProvider.GetService(iServiceType);
    }
}
