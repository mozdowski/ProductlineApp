import { EbayOfferDetails } from './createEbayAuctionRequest';

export interface EbayAuctionDetailsResponse {
  listingId: string;
  aspects: Record<string, string[]>;
  offerDetails: EbayOfferDetails;
}
