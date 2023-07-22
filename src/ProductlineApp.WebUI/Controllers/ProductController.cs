using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Application.Common.Platforms;
using ProductlineApp.Application.Products.Commands;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Application.Products.Queries;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUserContext _currentUser;
    private readonly IPlatformServiceDispatcher _platformServiceDispatcher;

    public ProductController(
        IMediator mediator,
        ICurrentUserContext currentUser,
        IPlatformServiceDispatcher platformServiceDispatcher)
    {
        this._mediator = mediator;
        this._currentUser = currentUser;
        this._platformServiceDispatcher = platformServiceDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetListOfUsersProducts()
    {
        var query = new GetAllUserProductsQuery.Query(this._currentUser.UserId.GetValueOrDefault());
        var response = await this._mediator.Send(query);

        return this.Ok(response);
    }

    [HttpGet("{productId:guid}")]
    public async Task<IActionResult> GetUsersProduct(Guid productId)
    {
        var query = new GetProductByIdQuery.Query(productId, this._currentUser.UserId.GetValueOrDefault());
        var response = await this._mediator.Send(query);

        return this.Ok(response);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct([FromForm] AddProductDtoRequest request)
    {
        var command = new AddProductCommand.Command(
            request.Sku,
            request.Name,
            request.CategoryName,
            request.Price,
            request.Quantity,
            request.Image,
            request.BrandName,
            request.Description,
            request.Condition,
            this._currentUser.UserId.GetValueOrDefault());
        var product = await this._mediator.Send(command);

        return this.Ok(new
        {
            ProductId = product.Id.Value,
        });
    }

    [HttpPost("{productId:guid}/addImageToGallery")]
    public async Task<IActionResult> AddImageToGallery(Guid productId, [FromForm] IFormFile image)
    {
        var command = new AddImageToGalleryCommand.Command(
            image,
            productId,
            this._currentUser.UserId.GetValueOrDefault());
        await this._mediator.Send(command);

        return this.Ok();
    }

    [HttpPost("{productId:guid}/updateInfo")]
    public async Task<IActionResult> UpdateProductInfo(Guid productId, [FromForm] EditProductDtoRequest request)
    {
        var command = new EditProductInfoCommand.Command(
            this._currentUser.UserId.GetValueOrDefault(),
            productId,
            request.Name,
            request.CategoryName,
            request.Price,
            request.Quantity,
            request.BrandName,
            request.Description,
            request.Gallery,
            request.ImageFile,
            request.ImageUrl);
        var response = await this._mediator.Send(command);

        return this.Ok(response);
    }

    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        var command = new DeleteProductCommand.Command(
            productId,
            this._currentUser.UserId.GetValueOrDefault());
        await this._mediator.Send(command);

        return this.Ok();
    }
}
