using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Contexts;
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

    public ProductController(
        IMediator mediator,
        ICurrentUserContext currentUser)
    {
        this._mediator = mediator;
        this._currentUser = currentUser;
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

    [HttpPost]
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
            this._currentUser.UserId.GetValueOrDefault());
        await this._mediator.Send(command);

        return this.Ok();
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

    [HttpPut("{productId:guid}/updateInfo")]
    public async Task<IActionResult> UpdateProductInfo(Guid productId, [FromBody] EditProductDtoRequest request)
    {
        var command = new EditProductInfoCommand.Command(
            productId,
            request.Name,
            request.CategoryName,
            request.Price,
            request.Quantity,
            request.BrandName,
            request.Description,
            this._currentUser.UserId.GetValueOrDefault());
        var response = await this._mediator.Send(command);

        return this.Ok(response);
    }

    [HttpPost("{productId:guid}/updateImage")]
    public async Task<IActionResult> UpdateProductImage(Guid productId, [FromForm] IFormFile image)
    {
        var command = new EditProductImageCommand.Command(
            this._currentUser.UserId.GetValueOrDefault(),
            productId,
            image);
        var result = await this._mediator.Send(command);

        return this.Ok(result);
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
