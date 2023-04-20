using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Common.Contexts;

public interface ICurrentUserContext
{
    Guid? UserId { get; }

    IDictionary<PlatformId, UserToken>? PlatformTokens { get; set; }
}
