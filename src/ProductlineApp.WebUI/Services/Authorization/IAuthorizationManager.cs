using Microsoft.AspNetCore.Authorization;

namespace ProductlineApp.WebUI.Services.Authorization;

public interface IAuthorizationManager : IAuthorizationService
{
    public Guid UserId { get; }
}
