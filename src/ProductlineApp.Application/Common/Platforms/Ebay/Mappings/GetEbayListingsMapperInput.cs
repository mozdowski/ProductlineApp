using ProductlineApp.Domain.Aggregates.Products;
using ProductlineApp.Shared.Models.Ebay;

namespace ProductlineApp.Application.Common.Platforms.Ebay.Mappings;

public class GetEbayListingsMapperInput
{
    public IEnumerable<EbayOffersReponse.Offer> EbayOffers { get; set; }

    public IEnumerable<Product> EbayProducts { get; set; }
}
