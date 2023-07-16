using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Shared.Enums;
using ProductlineApp.WebUI.DTO.Platforms;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/platforms")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformServiceDispatcher _platformServiceDispatcher;
    private readonly IPlatformRepository _platformRepository;
    private readonly ICurrentUserContext _userContext;

    public PlatformsController(
        IPlatformServiceDispatcher platformServiceDispatcher,
        IPlatformRepository platformRepository,
        ICurrentUserContext userContext)
    {
        this._platformServiceDispatcher = platformServiceDispatcher;
        this._platformRepository = platformRepository;
        this._userContext = userContext;
    }

    [HttpGet("auth/url")]
    public async Task<IActionResult> GetAuthorizationUrlForAll()
    {
        var platforms = await this._platformRepository.GetAllAsync();

        return this.Ok(platforms.Select(x => new
        {
            PlatformId = x.Id.Value,
            PlatformName = Enum.Parse<PlatformNames>(x.Name.ToUpper()),
            AuthUrl = this._platformServiceDispatcher.Dispatch(x.Id.Value).GetAuthorizationUrl(),
        }));
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

    [HttpPost("auth/gainToken/{platformId:guid}")]
    public async Task<IActionResult> GainAccessToken([FromBody] GainAccessTokenRequest request, Guid platformId)
    {
        var platformService = this._platformServiceDispatcher.Dispatch(platformId);
        await platformService.GainAccessTokenAsync(request.Code);

        return this.Ok();
    }

    [HttpGet("listings/{platformId:guid}")]
    public async Task<IActionResult> GetListings(Guid platformId)
    {
        if (!this._userContext.PlatformTokens.TryGetValue(PlatformId.Create(platformId), out var platformToken))
        {
            return this.Ok(new GetListingsResponse()
            {
                Listings = new List<ListingDtoResponse>(),
            });
        }

        var platformService = this._platformServiceDispatcher.Dispatch(platformId);
        var listings = await platformService.GetListingsAsync();

        return this.Ok(new GetListingsResponse()
        {
            Listings = listings,
        });
    }

    [HttpGet("getAllAvailable")]
    public async Task<IActionResult> GetAllAvailable()
    {
        var platforms = await this._platformRepository.GetAllAsync();
        return this.Ok(new
        {
            Platforms = platforms.Select(p => new PlatformResponse()
            {
                Id = p.Id.Value,
                Name = Enum.Parse<PlatformNames>(p.Name.ToUpper()),
            }),
        });
    }
}
