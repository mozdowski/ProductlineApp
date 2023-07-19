namespace ProductlineApp.Shared.Models.Ebay;

public class EbayFulfillmentPoliciesResponse
{
    public List<EbayFulfillmentPolicy> FulfillmentPolicies { get; set; }

    public class EbayFulfillmentPolicy
    {
        public string Name { get; set; }

        public string FulfillmentPolicyId { get; set; }
    }
}
