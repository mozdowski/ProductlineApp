using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.WebUI.Services.Products;

namespace ProductlineApp.WebUI.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet]
    [Route("/")]
    public Task<IActionResult> GetListOfProducts()
    {
    }
}
