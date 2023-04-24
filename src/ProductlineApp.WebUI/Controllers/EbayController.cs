using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms.Ebay.Services;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Shared.Models.Ebay;

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
    public async Task<IActionResult> AddOrUpdateProduct([FromForm] EbayProductDtoRequest request)
    {
        await this._ebayService.CreateOrReplaceInventoryItem(request);

        return this.Ok();
    }
}
