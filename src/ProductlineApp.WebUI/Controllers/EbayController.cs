using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Common.Platforms.Ebay.Services;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.WebUI.DTO.Product;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/ebay")]
public class EbayController : ControllerBase
{
    private readonly IEbayService _ebayService;
    private readonly IMapper _mapper;

    public EbayController(
        IEbayService ebayService,
        IMapper mapper)
    {
        this._ebayService = ebayService;
        this._mapper = mapper;
    }

    [HttpPost("addOrUpdateProduct")]
    public async Task<IActionResult> AddOrUpdateProduct([FromBody] ProductDtoRequest request)
    {
        var product = this._mapper.Map<Product>(request);
        await this._ebayService.CreateOrReplaceInventoryItem(product);

        return this.Ok();
    }
}
