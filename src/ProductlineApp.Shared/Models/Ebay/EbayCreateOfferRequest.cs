namespace ProductlineApp.Shared.Models.Ebay;

public class EbayCreateOfferRequest
{
    public string Sku { get; set; }

    public string MarketplaceId { get; set; }

    public string Format { get; set; }

    public string ListingDescription { get; set; }

    public int AvailableQuantity { get; set; }

    public int QuantityLimitPerBuyer { get; set; }

    public PricingSummaryObject PricingSummary { get; set; }

    public ListingPoliciesObject ListingPolicies { get; set; }

    public string CategoryId { get; set; }

    public string MerchantLocationKey { get; set; }

    public TaxObject Tax { get; set; }

    public class PricingSummaryObject
    {
        public Price Price { get; set; }
    }

    public class Price
    {
        public decimal Value { get; set; }

        public string Currency { get; set; }
    }

    public class ListingPoliciesObject
    {
        public string FulfillmentPolicyId { get; set; }

        public string PaymentPolicyId { get; set; }

        public string ReturnPolicyId { get; set; }
    }

    public class TaxObject
    {
        public decimal VatPercentage { get; set; }

        public bool ApplyTax { get; set; }

        public string ThirdPartyTaxCategory { get; set; }
    }
}
