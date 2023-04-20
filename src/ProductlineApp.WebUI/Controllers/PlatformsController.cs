using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.WebUI.DTO.Platforms;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/platforms")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformServiceDispatcher _platformServiceDispatcher;

    public PlatformsController(
        IPlatformServiceDispatcher platformServiceDispatcher)
    {
        this._platformServiceDispatcher = platformServiceDispatcher;
    }

    [HttpGet("auth/url/{platformId:guid}")]
    public IActionResult GetAuthorizationUrl(Guid platformId)
    {
        var platformService = this._platformServiceDispatcher.Dispatch(platformId);
        var authUrl = platformService.GetAuthorizationUrl();

        return this.Ok(new
        {
            authorizationUrl = authUrl,
        });
    }

    [HttpPut("auth/gainToken/{platformId:guid}")]
    public async Task<IActionResult> GainAccessToken([FromBody] GainAccessTokenRequest request, Guid platformId)
    {
        var platformService = this._platformServiceDispatcher.Dispatch(platformId);
        await platformService.GainAccessTokenAsync(request.Code);

        return this.Ok();
    }
}
