using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Shared.Models.Common;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Services;

public interface IEbayService : IPlatformService
{
    // Task CreateOrReplaceInventoryItem(EbayProductDtoRequest product);

    Task CreateListingAsync(EbayListingDtoRequest request);

    Task<PlatformAspectsDtoResponse> GetAspectsForCategory(string categoryId);

    Task<PlatformCategoriesListDto> GetCategoriesByPhrase(string phrase);

    Task<EbayCategoryTreeDto> GetCategories();

    Task<EbayLocationsDtoResponse> GetLocations();

    Task<EbayUserPolicies> GetUserPolicies();
}
