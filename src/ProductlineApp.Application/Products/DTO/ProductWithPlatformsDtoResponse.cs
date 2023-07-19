using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Products.DTO;

public class ProductWithPlatformsDtoResponse : ProductDtoResponse
{
    public IEnumerable<PlatformNames> Platforms { get; set; }
}
