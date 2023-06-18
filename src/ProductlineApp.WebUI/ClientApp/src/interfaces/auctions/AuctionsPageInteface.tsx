export interface AuctionsPage {
  auctionsTableRecords: AuctionsRecord[];
}

export interface AuctionsRecord {
  auctionID: string;
  sku: string;
  brand: string;
  productName: string;
  category: string;
  price: number;
  quantity: number;
  daysToEnd: number | undefined;
}
