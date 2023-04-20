using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms.Allegro.Services;

namespace ProductlineApp.WebUI.Controllers;

// [Authorize]
[ApiController]
[Route("api/allegro")]
public class AllegroController : ControllerBase
{
    // private readonly IAllegroService _allegroApiService;

    // public AllegroController(
    //     IAllegroService allegroApiService)
    // {
    //     this._allegroApiService = allegroApiService;
    // }

    [HttpGet]
    [Route("productList")]
    public async Task<IActionResult> GetProductList(string phrase)
    {
        return this.Ok();
    }
}
