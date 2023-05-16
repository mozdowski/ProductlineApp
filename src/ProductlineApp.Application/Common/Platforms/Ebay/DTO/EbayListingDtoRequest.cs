using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Shared.Models.Common;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayListingDtoRequest
{
    public Guid ListingId { get; set; }

    public IDictionary<string, IEnumerable<string>> Aspects { get; set; }

    public EbayOfferDtoRequest OfferDetails { get; set; }
}
