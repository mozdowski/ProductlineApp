namespace ProductlineApp.Shared.Models.Ebay;

public class EbayUpdateOfferRequest
{
    public string ListingDescription { get; set; }

    public int AvailableQuantity { get; set; }

    public int? QuantityLimitPerBuyer { get; set; }

    public PricingSummaryObject PricingSummary { get; set; }

    public ListingPoliciesObject ListingPolicies { get; set; }

    public string CategoryId { get; set; }

    public string MerchantLocationKey { get; set; }

    public class PricingSummaryObject
    {
        public Price Price { get; set; }
    }

    public class Price
    {
        public decimal Value { get; set; }

        public string Currency { get; set; } = "PLN";
    }

    public class ListingPoliciesObject
    {
        public string FulfillmentPolicyId { get; set; }

        public string PaymentPolicyId { get; set; }

        public string ReturnPolicyId { get; set; }
    }
}
