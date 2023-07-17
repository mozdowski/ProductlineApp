using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Common.Platforms.Ebay.Services;
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

    // [HttpPost("addOrUpdateProduct")]
    // public async Task<IActionResult> AddOrUpdateProduct([FromForm] EbayProductDtoRequest request)
    // {
    //     await this._ebayService.CreateOrReplaceInventoryItem(request);
    //
    //     return this.Ok();
    // }

    [HttpPost("createListing")]
    public async Task<IActionResult> CreateEbayListing([FromBody] EbayListingDtoRequest request)
    {
        await this._ebayService.CreateListingAsync(request);

        return this.Ok();
    }

    [HttpGet("categories/suggestions/{phrase}")]
    public async Task<IActionResult> GetCategoriesSuggestions(string phrase)
    {
        var response = await this._ebayService.GetCategoriesByPhrase(phrase.Trim());

        return this.Ok(response);
    }

    [HttpGet("categories/tree")]
    public async Task<IActionResult> GetCategoryTree()
    {
        var response = await this._ebayService.GetCategories();

        return this.Ok(response);
    }

    [HttpGet("aspectsForCategory/{categoryId}")]
    public async Task<IActionResult> GetAspectsForCategory(string categoryId)
    {
        var response = await this._ebayService.GetAspectsForCategory(categoryId);

        return this.Ok(response);
    }

    [HttpGet("locations")]
    public async Task<IActionResult> GetMerchantLocations()
    {
        var response = await this._ebayService.GetLocations();

        return this.Ok(response);
    }

    [HttpGet("userPolicies")]
    public async Task<IActionResult> GetUserPolicies()
    {
        var response = await this._ebayService.GetUserPolicies();

        return this.Ok(response);
    }
}
