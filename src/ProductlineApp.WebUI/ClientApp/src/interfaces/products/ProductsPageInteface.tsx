export interface ProductsPage {
  productsTableRecords: ProductsRecord[];
}

export interface ProductsRecord {
  sku: string;
  brand: string;
  productName: string;
  category: string;
  price: number;
  quantity: number;
  status: string;
  quality: string;
}
