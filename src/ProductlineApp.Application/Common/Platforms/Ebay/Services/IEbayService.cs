using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Application.Products.DTO;
using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Services;

public interface IEbayService : IPlatformService
{
    Task CreateOrReplaceInventoryItem(EbayProductDtoRequest product);
}
