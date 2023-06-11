using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Application.Order.Commands;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IPlatformServiceDispatcher _platformServiceDispatcher;
    private readonly ICurrentUserContext _currentUser;
    private readonly IMediator _mediator;

    public OrdersController(
        IPlatformServiceDispatcher platformServiceDispatcher,
        ICurrentUserContext currentUser,
        IMediator mediator)
    {
        this._platformServiceDispatcher = platformServiceDispatcher;
        this._currentUser = currentUser;
        this._mediator = mediator;
    }

    [HttpGet("{platformId:guid}")]
    public async Task<IActionResult> GetOrders(Guid platformId)
    {
        var platformService = this._platformServiceDispatcher.Dispatch(platformId);
        var orders = await platformService.GetOrdersAsync();

        return this.Ok(orders);
    }

    [HttpPost("{orderId:guid}")]
    public async Task<IActionResult> AttachDocumentToOrder(Guid orderId, [FromForm] IFormFile document)
    {
        var command = new AttachDocumentCommand.Command(
            this._currentUser.UserId.GetValueOrDefault(),
            orderId,
            document);
        await this._mediator.Send(command);

        return this.Ok();
    }
}
