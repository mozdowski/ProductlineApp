using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Authentication.Commands;
using ProductlineApp.Application.Authentication.Queries;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.User.Commands;
using ProductlineApp.Shared.Models.Authentication.Requests.Auth;

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

    [HttpPut("updateAvatar")]
    public async Task<IActionResult> UpdateAvatar([FromForm] IFormFile avatar)
    {
        var command = new UpdateAvatarCommand.Command(this._currentUser.UserId.GetValueOrDefault(), avatar);
        var result = await this._mediator.Send(command);

        return this.Ok(result);
    }
}
