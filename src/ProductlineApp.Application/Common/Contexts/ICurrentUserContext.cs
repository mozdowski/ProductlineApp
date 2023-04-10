using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Common.Contexts;

public interface ICurrentUserContext
{
    Guid UserId { get; }

    IDictionary<PlatformNames, UserToken> PlatformTokens { get; set; }
}
