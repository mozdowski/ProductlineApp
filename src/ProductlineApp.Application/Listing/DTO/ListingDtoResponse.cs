using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Application.Listing.DTO;

public class ListingDtoResponse
{
    public string Title { get; set; }

    public string Description { get; set; }

    public Guid ListingInstanceId { get; set; }

    public Guid ListingId { get; set; }

    public string PlatformListingId { get; set; }

    public string? PlatformListingUrl { get; set; }

    public string Brand { get; set; }

    public Guid ProductId { get; set; }

    public string Sku { get; set; }

    public string ProductImageUrl { get; set; }

    public string ProductName { get; set; }

    public string Category { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int? DaysToExpire { get; set; }

    public int IsActive { get; set; }
}
