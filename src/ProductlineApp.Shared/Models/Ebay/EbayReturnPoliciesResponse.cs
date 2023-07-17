namespace ProductlineApp.Shared.Models.Ebay;

public class EbayReturnPoliciesResponse
{
    public List<EbayReturnPolicy> ReturnPolicies { get; set; }

    public class EbayReturnPolicy
    {
        public string Name { get; set; }

        public string ReturnPolicyId { get; set; }
    }
}
