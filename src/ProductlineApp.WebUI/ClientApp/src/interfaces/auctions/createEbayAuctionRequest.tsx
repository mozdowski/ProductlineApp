export interface CreateEbayAuctionRequest {
  listingId: string;
  aspects: Record<string, string[]>;
  offerDetails: EbayOfferDetails;
}

export interface EbayOfferDetails {
  listingDescription: string;
  quantity: number;
  quantityLimitPerBuyer?: number;
  categoryId: string;
  price: number;
  fulfillmentPolicyId: string;
  paymentPolicyId: string;
  returnPolicyId: string;
  locationKey: string;
}
