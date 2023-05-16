namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayOfferDtoRequest
{
    public string MarketplaceId { get; set; } = "EBAY_PL";

    public string Format { get; set; } = "FIXED_PRICE";

    public string ListingDescription { get; set; }

    public int Quantity { get; set; }

    public int? QuantityLimitPerBuyer { get; set; }

    public string CategoryId { get; set; }

    // public string MerchantLocationKey { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; } = "PLN";

    public string FulfillmentPolicyId { get; set; }

    public string PaymentPolicyId { get; set; }

    public string ReturnPolicyId { get; set; }

    // public decimal VatPercentage { get; set; }
    //
    // public bool ApplyTax { get; set; }
    //
    // public string ThirdPartyTaxCategory { get; set; }
}
