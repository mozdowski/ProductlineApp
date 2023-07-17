namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayUserPolicies
{
    public IEnumerable<EbayUserPolicy> FulfillmentPolicies { get; set; }

    public IEnumerable<EbayUserPolicy> PaymentPolicies { get; set; }

    public IEnumerable<EbayUserPolicy> ReturnPolicies { get; set; }

    public IEnumerable<EbayUserPolicy> LocationKeys { get; set; }

    public class EbayUserPolicy
    {
        public string Name { get; set; }

        public string Id { get; set; }
    }
}
