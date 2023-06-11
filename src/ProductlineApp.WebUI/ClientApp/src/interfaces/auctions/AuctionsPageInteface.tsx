export interface AuctionsPage {
    auctionsTableRecords: AuctionsRecord[];
}


export interface AuctionsRecord {
    AuctionID: number
    SKU: string;
    Brand: string;
    ProductName: string;
    Category: string;
    Price: number;
    Quantity: number;
    DaysToEnd: number;
}