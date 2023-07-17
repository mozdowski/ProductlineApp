namespace ProductlineApp.Shared.Models.Ebay;

public class EbayPaymentPoliciesResponse
{
    public List<EbayPaymentPolicy> PaymentPolicies { get; set; }

    public class EbayPaymentPolicy
    {
        public string Name { get; set; }

        public string PaymentPolicyId { get; set; }
    }
}
