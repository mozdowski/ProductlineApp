using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Authentication.Commands;
using ProductlineApp.Application.Authentication.Queries;
using ProductlineApp.Shared.Models.Authentication.Requests.Auth;

namespace ProductlineApp.WebUI.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(
        IMediator mediator,
        IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterRequest request)
    {
        var command = this._mapper.Map<RegisterCommand.Command>(request);
        var response = await this._mediator.Send(command);

        return this.Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = this._mapper.Map<LoginQuery.Query>(request);
        var response = await this._mediator.Send(command);

        return this.Ok(response);
    }
}
