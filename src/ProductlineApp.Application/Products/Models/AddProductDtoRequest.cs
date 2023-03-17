using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Application.Products.Models;

public class AddProductDtoRequest
{
    public string ProductId { get; set; }

    public string Name { get; set; }

    public Guid CategoryId { get; set; }

    public decimal Price { get; set; }

    public int? Quantity { get; set; }

    public Image? Image { get; set; }

    public string Brand { get; set; }

    public string Description { get; set; }
}
