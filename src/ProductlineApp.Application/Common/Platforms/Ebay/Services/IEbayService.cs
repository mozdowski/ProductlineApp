using ProductlineApp.Application.Common.Platforms.Ebay.DTO;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Domain.Aggregates.Products;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Services;

public interface IEbayService : IPlatformService
{
    Task CreateOrReplaceInventoryItem(Product product);
}
