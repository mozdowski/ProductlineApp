import { Platform } from '../../enums/platform.enum';

export interface ProductsPage {
  productsTableRecords: ProductsRecord[];
}

export interface ProductsRecord {
  sku: string;
  brand: string;
  productName: string;
  category: string;
  price: number;
  imageUrl: string;
  quantity: number;
  condition: string;
  quality: string;
  galleryUrls: string[];
  platforms: Platform[];
}
