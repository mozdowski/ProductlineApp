using ProductlineApp.Domain.Aggregates.Products.ValueObjects;

namespace ProductlineApp.Application.Listing.DTO;

public class ListingTemplateDtoRequest
{
    public string Title { get; set; }

    public Guid ProductId { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}
