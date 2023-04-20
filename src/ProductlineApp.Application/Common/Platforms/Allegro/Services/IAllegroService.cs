using ProductlineApp.Application.Common.Platforms.Allegro.DTO;
using ProductlineApp.Application.Common.Services.Interfaces;

namespace ProductlineApp.Application.Common.Platforms.Allegro.Services;

public interface IAllegroService : IPlatformService
{
    Task<AllegroProductListDto> GetProductList(string phrase);

    Task<string> CreateListingBasedOnAllegroProductAsync();
}
