export interface EbayUserPoliciesResponse {
  fulfillmentPolicies: EbayPolicy[];
  paymentPolicies: EbayPolicy[];
  returnPolicies: EbayPolicy[];
  locationKeys: EbayPolicy[];
}

interface EbayPolicy {
  id: string;
  name: string;
}
