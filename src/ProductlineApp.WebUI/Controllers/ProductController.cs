using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Product.Queries;
using ProductlineApp.WebUI.Services.Authorization;

namespace ProductlineApp.WebUI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAuthorizationManager _authorizationManager;

    public ProductController(
        IMediator mediator,
        IAuthorizationManager authorizationManager)
    {
        this._mediator = mediator;
        this._authorizationManager = authorizationManager;
    }

    [HttpGet]
    [Route("/")]
    public async Task<IActionResult> GetListOfProducts()
    {
        var query = new GetAllUserProductsQuery.Query(this._authorizationManager.UserId);
        var response = this._mediator.Send(query);
        return this.Ok(response);
    }
}
