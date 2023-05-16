using ProductlineApp.Domain.Aggregates.Listing.ValueObjects;

namespace ProductlineApp.Application.Listing.DTO;

public class ListingInstanceDtoResponse
{
    public Guid Id { get; set; }

    public Guid PlatformId { get; set; }

    public ListingStatus Status { get; set; }
}
