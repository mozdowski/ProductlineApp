using ProductlineApp.Application.Common.Services.Interfaces;

namespace ProductlineApp.Application.Common.Platforms;

public interface IPlatformServiceDispatcher
{
    IPlatformService Dispatch(Guid platformId);
}
