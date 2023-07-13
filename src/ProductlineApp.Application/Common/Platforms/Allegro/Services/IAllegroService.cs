using ProductlineApp.Application.Common.Platforms.Allegro.DTO;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Shared.Models.Allegro;

namespace ProductlineApp.Application.Common.Platforms.Allegro.Services;

public interface IAllegroService : IPlatformService
{
    Task<AllegroProductListDto> GetProductList(string phrase);

    Task CreateListingBasedOnAllegroProductAsync(AllegroCreateListingDtoRequest request);

    Task<string> GetProductParametersForCategory(string categoryId);

    Task<AllegroCatalogueProductDetailsResponse> GetCatalogueProductDetails(string productId);

    Task<ShippingRatesResponse> GetShippingRates();

    Task<ReturnPoliciesResponse> GetReturnPolicies();

    Task<ImpliedWarrantiesResponse> GetImpliedWarranties();

    Task<AllegroOfferProductDtoResponse> GetOfferProductDetails(string offerId);
}
