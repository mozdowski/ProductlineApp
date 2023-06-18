namespace ProductlineApp.Application.Listing.DTO;

public class GetListingsResponse
{
    public IEnumerable<ListingDtoResponse> Listings { get; set; }
}
