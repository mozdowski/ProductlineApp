using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Application.Listing.Commands;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Application.Listing.Queries;
using ProductlineApp.Domain.Aggregates.Listing.Repository;
using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/listings")]
public class ListingController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUserContext _currentUser;
    private readonly IPlatformServiceDispatcher _platformServiceDispatcher;
    private readonly IListingRepository _listingRepository;

    public ListingController(
        IMediator mediator,
        ICurrentUserContext currentUser,
        IPlatformServiceDispatcher platformServiceDispatcher,
        IListingRepository listingRepository)
    {
        this._mediator = mediator;
        this._currentUser = currentUser;
        this._platformServiceDispatcher = platformServiceDispatcher;
        this._listingRepository = listingRepository;
    }

    [HttpPost("createTemplate")]
    public async Task<IActionResult> CreateListingTemplate([FromBody] ListingTemplateDtoRequest request)
    {
        var command = new CreateListingTemplateCommand.Command(
            this._currentUser.UserId.GetValueOrDefault(),
            request.Title,
            request.Description,
            request.ProductId,
            request.Price,
            request.Quantity);
        var response = await this._mediator.Send(command);

        return this.Ok(response);
    }

    [HttpGet("getTemplates")]
    public async Task<IActionResult> GetAllUserListingTemplates()
    {
        var query = new GetUserListingsQuery.Query(this._currentUser.UserId.GetValueOrDefault());
        var response = await this._mediator.Send(query);

        return this.Ok(response);
    }

    [HttpGet("{listingId:guid}")]
    public async Task<IActionResult> GetListing(Guid listingId)
    {
        var query = new GetListingByIdQuery.Query(
            this._currentUser.UserId.GetValueOrDefault(),
            listingId);
        var response = await this._mediator.Send(query);

        return this.Ok(response);
    }

    // [HttpPost("{listingId:guid}/publishEverywhere")]
    // public async Task<IActionResult> PublishListingOnEveryPlatform(Guid listingId)
    // {
    //     var query = new GetListingByIdQuery.Query(
    //         this._currentUser.UserId.GetValueOrDefault(),
    //         listingId);
    //     var listing = await this._mediator.Send(query);
    //
    //     foreach (var li in listing.ListingInstances)
    //     {
    //         var platformService = this._platformServiceDispatcher.Dispatch(li.PlatformId);
    //         await platformService.PublishListingAsync(
    //             ListingId.Create(listingId),
    //             ListingInstanceId.Create(li.Id));
    //     }
    //
    //     return this.Ok();
    // }

    // [HttpPost("{listingId:guid}/withdrawEverywhere")]
    // public async Task<IActionResult> WithdrawListingOnEveryPlatform(Guid listingId)
    // {
    //     var query = new GetListingByIdQuery.Query(
    //         this._currentUser.UserId.GetValueOrDefault(),
    //         listingId);
    //     var listing = await this._mediator.Send(query);
    //
    //     foreach (var li in listing.ListingInstances)
    //     {
    //         var platformService = this._platformServiceDispatcher.Dispatch(li.PlatformId);
    //         await platformService.WithdrawListingAsync(
    //             ListingId.Create(listingId),
    //             ListingInstanceId.Create(li.Id));
    //     }
    //
    //     return this.Ok();
    // }
    //
    // [HttpPost("{listingId:guid}/publish/{listingInstanceId:guid}")]
    // public async Task<IActionResult> PublishListingInstance(Guid listingId, Guid listingInstanceId)
    // {
    //     var platformId = await this.GetPlatformIdByListingInstance(listingId, listingInstanceId);
    //     var platformService = this._platformServiceDispatcher.Dispatch(platformId);
    //
    //     await platformService.PublishListingAsync(
    //         ListingId.Create(listingId),
    //         ListingInstanceId.Create(listingInstanceId));
    //
    //     return this.Ok();
    // }

    [HttpGet("getPlatformsWithListings")]
    public async Task<IActionResult> GetPlatformsWithListings()
    {
        var query = new GetPlatformsWithListingsQuery.Query(this._currentUser.UserId.GetValueOrDefault());
        var response = await this._mediator.Send(query);

        return this.Ok(response);
    }

    private async Task<Guid> GetPlatformIdByListingInstance(Guid listingId, Guid listingInstanceId)
    {
        var query = new GetInstancePublishDataQuery.Query(
            listingId,
            listingInstanceId,
            this._currentUser.UserId.GetValueOrDefault());
        var publishDto = await this._mediator.Send(query);

        return publishDto.PlatformId;
    }
}
