export interface GetAuctionsResponse {
  listings: Auction[];
}

interface Auction {
  title: string;
  description: string;
  listingId: string;
  platformListingId: string;
  listingInstanceId: string;
  platformListingUrl?: string;
  productId: string;
  sku: string;
  brand: string;
  productImageUrl: string;
  productName: string;
  category: string;
  price: number;
  quantity: number;
  daysToExpire?: number;
  isActive: boolean;
}
