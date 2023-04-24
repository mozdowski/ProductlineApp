using ProductlineApp.Application.Authentication.DTO;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.WebUI.Services.Authorization;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<IDictionary<PlatformId, UserToken>?> GetPlatformTokens(Guid? userId)
    {
        if (!userId.HasValue || userId.Value == Guid.Empty) return null;
        var pcs = await this._userRepository
            .GetUserPlatformConnectionsAsync(UserId.Create(userId.Value));

        return pcs.ToDictionary(
            k => k.PlatformId,
            v => new UserToken(v.AccessToken, v.RefreshToken, v.ExpirationDate));
    }

    public async Task<bool> IsUserExisting(Guid? userId)
    {
        if (userId == Guid.Empty || !userId.HasValue)
        {
            return false;
        }

        if (await this._userRepository.IsUserExistingAsync(UserId.Create(userId.Value)))
        {
            return true;
        }

        throw new UnauthorizedAccessException($"User with id: {userId.Value} not found");
    }
}
