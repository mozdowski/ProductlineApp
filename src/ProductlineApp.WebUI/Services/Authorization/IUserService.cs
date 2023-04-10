using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.WebUI.Services.Authorization;

public interface IUserService
{
    Task<IDictionary<PlatformNames, UserToken>> GetPlatformTokens(Guid userId);
}
