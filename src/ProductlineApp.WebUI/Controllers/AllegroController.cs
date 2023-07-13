using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms.Allegro.DTO;
using ProductlineApp.Application.Common.Platforms.Allegro.Services;

namespace ProductlineApp.WebUI.Controllers;

[Authorize]
[ApiController]
[Route("api/allegro")]
public class AllegroController : ControllerBase
{
    private readonly IAllegroService _allegroService;

    public AllegroController(
        IAllegroService allegroService)
    {
        this._allegroService = allegroService;
    }

    [HttpGet("productList")]
    public async Task<IActionResult> GetProductList(string phrase)
    {
        var result = await this._allegroService.GetProductList(phrase);
        return this.Ok(result);
    }

    [HttpPost("createListing")]
    public async Task<IActionResult> CreateEbayListing([FromBody] AllegroCreateListingDtoRequest request)
    {
        await this._allegroService.CreateListingBasedOnAllegroProductAsync(request);
        return this.Ok();
    }

    [HttpGet("product/categoryParameters/{categoryId}")]
    public async Task<IActionResult> GetCategoryParameters(string categoryId)
    {
        var result = await this._allegroService.GetProductParametersForCategory(categoryId);
        return this.Ok(result);
    }

    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetCatalogueProductDetails(string productId)
    {
        var result = await this._allegroService.GetCatalogueProductDetails(productId);
        return this.Ok(result);
    }

    [HttpGet("userPolicies")]
    public async Task<IActionResult> GetUserPolicies()
    {
        var impliesWarranties = this._allegroService.GetImpliedWarranties();
        var shippingRates = this._allegroService.GetShippingRates();
        var retunPolicies = this._allegroService.GetReturnPolicies();

        await Task.WhenAll(impliesWarranties, shippingRates, retunPolicies);

        return this.Ok(new
        {
            ImpliesWarranties = impliesWarranties.Result.ImpliedWarranties,
            ShippingRates = shippingRates.Result.ShippingRates,
            RetunPolicies = retunPolicies.Result.ReturnPolicies,
        });
    }

    [HttpGet("offerProductDetails/{offerId}")]
    public async Task<IActionResult> GetOfferProductDetails(string offerId)
    {
        var result = await this._allegroService.GetOfferProductDetails(offerId);
        return this.Ok(result);
    }
}
