using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductlineApp.Application.Common.Platforms.Allegro.Services;

namespace ProductlineApp.WebUI.Controllers;

[ApiController]
[Route("api/allegro")]
[Authorize]
public class AllegroController : ControllerBase
{
    private readonly IAllegroApiService _allegroApiService;

    public AllegroController(
        IAllegroApiService allegroApiService)
    {
        this._allegroApiService = allegroApiService;
    }

    [HttpGet]
    [Route("/productList")]
    public async Task<IActionResult> GetProductList(string phrase)
    {
        return this.Ok();
    }
}
