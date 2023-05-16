namespace ProductlineApp.Application.Listing.DTO;

public class GetUserListingsResponse
{
    public IEnumerable<ListingTemplateDtoRequest> Listings { get; set; }
}
