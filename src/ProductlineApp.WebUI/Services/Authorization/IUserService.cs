using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.WebUI.Services.Authorization;

public interface IUserService
{
    Task<IDictionary<PlatformId, UserToken>?> GetPlatformTokens(Guid? userId);
}
