namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayOfferDtoResponse
{
    public string ListingDescription { get; set; }

    public int Quantity { get; set; }

    public int? QuantityLimitPerBuyer { get; set; }

    public string CategoryId { get; set; }

    public decimal Price { get; set; }

    public string FulfillmentPolicyId { get; set; }

    public string PaymentPolicyId { get; set; }

    public string ReturnPolicyId { get; set; }

    public string LocationKey { get; set; }
}
