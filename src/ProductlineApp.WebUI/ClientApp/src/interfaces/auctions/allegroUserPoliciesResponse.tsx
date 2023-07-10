export interface AllegroUserPoliciesResponse {
  impliesWarranties: AllegroPolicy[];
  shippingRates: AllegroPolicy[];
  retunPolicies: AllegroPolicy[];
}

export interface AllegroPolicy {
  id: string;
  name: string;
}
