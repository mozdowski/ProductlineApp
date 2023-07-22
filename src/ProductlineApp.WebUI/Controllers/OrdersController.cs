using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Application.Order.Commands;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Application.Order.Queries;
using ProductlineApp.Domain.Aggregates.Order.Entities;

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

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var response = new GetAllOrdersDtoResponse()
        {
            Orders = new List<OrderDtoResponse>(),
        };

        var offlineOrders = await this._mediator.Send(new GetOfflineOrdersQuery.Query(this._currentUser.UserId.GetValueOrDefault()));

        response.Orders.AddRange(offlineOrders);

        var userPlatforms = this._currentUser.PlatformTokens?.Keys.ToList();

        if (userPlatforms is null)
        {
            return this.Ok(response);
        }

        foreach (var platformService in userPlatforms.Select(platformId => this._platformServiceDispatcher.Dispatch(platformId.Value)))
        {
            var platformOrders = await platformService.GetOrdersAsync();

            if (platformOrders.Count() == 0)
            {
                continue;
            }

            foreach (var platformOrder in platformOrders)
            {
                var command = new CreateOrderCommand.Command(
                    this._currentUser.UserId.GetValueOrDefault(),
                    platformOrder.Items,
                    platformOrder.ShippingAddress,
                    platformOrder.BillingAddress,
                    platformService.PlatformId.Value,
                    platformOrder.PlatformOrderId,
                    platformOrder.Status,
                    platformOrder.CreationDate,
                    platformOrder.IsPaid,
                    platformOrder.SubtotalPrice,
                    platformOrder.DeliveryCost,
                    platformOrder.MaxDeliveryDate.GetValueOrDefault());
                var orderId = await this._mediator.Send(command);

                if (orderId == Guid.Empty)
                {
                    continue;
                }

                platformOrder.OrderId = orderId;
                response.Orders.Add(platformOrder);
            }
        }

        return this.Ok(response);
    }

    [HttpGet("{platformId:guid}")]
    public async Task<IActionResult> GetPlatformOrders(Guid platformId)
    {
        var platformService = this._platformServiceDispatcher.Dispatch(platformId);
        var orders = await platformService.GetOrdersAsync();

        return this.Ok(orders);
    }

    [HttpPost("{orderId:guid}/attachDocument")]
    public async Task<IActionResult> AttachDocumentToOrder(Guid orderId, [FromForm] IFormFile document)
    {
        var command = new AttachDocumentCommand.Command(
            this._currentUser.UserId.GetValueOrDefault(),
            orderId,
            document);
        await this._mediator.Send(command);

        return this.Ok();
    }

    [HttpDelete("{orderId:guid}/deleteDocument/{documentId:guid}")]
    public async Task<IActionResult> DeleteDocument(Guid orderId, Guid documentId)
    {
        var command = new DeleteDocumentCommand.Command(
            this._currentUser.UserId.GetValueOrDefault(),
            orderId,
            documentId);
        await this._mediator.Send(command);

        return this.Ok();
    }

    [HttpPost("markCompleted/{orderId:guid}")]
    public async Task<IActionResult> MarkOrderAsCompleted(Guid orderId)
    {
        var command = new MarkOrderAsCompletedCommand.Command(orderId);
        await this._mediator.Send(command);

        return this.Ok();
    }

    [HttpGet("{orderId:guid}/documents")]
    public async Task<IActionResult> GetOrderDocuments(Guid orderId)
    {
        var command = new GetOrderDocumentsQuery.Query(
            this._currentUser.UserId.GetValueOrDefault(),
            orderId);
        var response = await this._mediator.Send(command);

        return this.Ok(response);
    }
}
