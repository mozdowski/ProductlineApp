export interface ProductsPage {
    productsTableRecords: ProductsRecord[];
}


export interface ProductsRecord {
    SKU: string;
    Brand: string;
    ProductName: string;
    Category: string;
    Price: number;
    Quantity: number;
    Status: string;
    Quality: string
}