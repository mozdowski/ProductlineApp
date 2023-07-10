using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Products.DTO;

public class ProductDtoResponse
{
    public Guid Id { get; set; }

    public string Sku { get; set; }

    public string Name { get; set; }

    public string? Category { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string ImageUrl { get; set; }

    public string Brand { get; set; }

    public string Description { get; set; }

    public ProductCondition Condition { get; set; }

    public IEnumerable<PlatformNames> Platforms { get; set; }

    public List<string> Gallery { get; set; }
}
