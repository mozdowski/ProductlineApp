using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms.Allegro.DTO;
using ProductlineApp.Application.Common.Platforms.Allegro.Services;
using ProductlineApp.WebUI.DTO;

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

    [HttpPost("updateListing/{offerId}")]
    public async Task<IActionResult> UpdateListing(string offerId, [FromBody] AllegroUpdateListingDtoRequest request)
    {
        await this._allegroService.UpdateListing(offerId, request);
        return this.Ok();
    }

    [HttpPost("withdrawListing")]
    public async Task<IActionResult> WithdrawListing([FromBody] WithdrawAllegroListingDtoRequest request)
    {
        await this._allegroService.WithdrawListing(request.OfferId);
        return this.Ok();
    }

    [HttpPost("listingRenewal")]
    public async Task<IActionResult> ListingRenewal([FromBody] AllegroListingRenewalDtoRequest request)
    {
        await this._allegroService.ListingRenewal(request.OfferId);
        return this.Ok();
    }
}
