using ProductlineApp.Application.Common.Platforms.Ebay.DTO;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Mappings;

public class EbayCreateOfferMapperInput
{
    public EbayOfferDtoRequest OfferDetails { get; set; }

    public string EbayItemSku { get; set; }
}
