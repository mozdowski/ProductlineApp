using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Authentication.Commands;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.User.Commands;
using ProductlineApp.WebUI.DTO;
using ProductlineApp.WebUI.DTO.Platforms;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUserContext _currentUser;

    public UserController(
        IMediator mediator,
        ICurrentUserContext currentUser)
    {
        this._mediator = mediator;
        this._currentUser = currentUser;
    }

    [HttpPost("updateAvatar")]
    public async Task<IActionResult> UpdateAvatar([FromForm] IFormFile avatar)
    {
        var command = new UpdateAvatarCommand.Command(this._currentUser.UserId.GetValueOrDefault(), avatar);
        var result = await this._mediator.Send(command);

        return this.Ok(result);
    }

    [HttpGet("platformConnections")]
    public async Task<IActionResult> GetPlatformConnections()
    {
        return this.Ok(this._currentUser.PlatformTokens.Keys.Select(x => x.Value.ToString()).ToList());
    }

    [HttpPost("disconnectPlatform")]
    public async Task<IActionResult> GainAccessToken([FromBody] DisconnectPlatformRequest request)
    {
        var command = new DisconnectPlatformCommand.Command(
            request.PlatformId,
            this._currentUser.UserId.GetValueOrDefault());
        await this._mediator.Send(command);

        return this.Ok();
    }

    [HttpPost("changePassword")]
    public async Task<IActionResult> Login([FromBody] ChangePasswordRequest request)
    {
        var command = new ChangePasswordCommand.Command(
            this._currentUser.UserId.GetValueOrDefault(),
            request.OldPassword,
            request.NewPassword);
        await this._mediator.Send(command);

        return this.Ok();
    }
}
