namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayOfferDetailsResponse
{
    public Guid ListingId { get; set; }

    public IDictionary<string, List<string>> Aspects { get; set; }

    public EbayOfferDtoResponse OfferDetails { get; set; }
}
