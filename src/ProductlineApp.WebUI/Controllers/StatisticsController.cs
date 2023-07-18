using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Statictics.Queries;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/statistics")]
public class StatisticsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUserContext _currentUser;

    public StatisticsController(
        IMediator mediator,
        ICurrentUserContext currentUser)
    {
        this._mediator = mediator;
        this._currentUser = currentUser;
    }

    [HttpGet("auctions")]
    public async Task<IActionResult> GetAuctionsData()
    {
        var command = new GetAuctionStatisticsQuery.Query(this._currentUser.UserId.GetValueOrDefault());
        var result = await this._mediator.Send(command);

        return this.Ok(result);
    }

    [HttpGet("mostPopularProducts")]
    public async Task<IActionResult> GetMostPopularProductsData()
    {
        var command = new GetMostPopularProductsQuery.Query(this._currentUser.UserId.GetValueOrDefault());
        var result = await this._mediator.Send(command);

        return this.Ok(result);
    }
}
