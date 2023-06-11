using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.WebUI.Services.Authorization;

public interface IUserService
{
    Task<IDictionary<PlatformId, UserToken>?> GetPlatformTokens(Guid? userId);

    Task<bool> IsUserExisting(Guid? userId);
}
