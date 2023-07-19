import { PlatformEnum } from '../../enums/platform.enum';

export interface ProductsPage {
  productsTableRecords: ProductsRecord[];
}

export interface ProductsRecord {
  id: string;
  sku: string;
  brand: string;
  productName: string;
  category: string;
  price: number;
  imageUrl: string;
  quantity: number;
  condition: string;
  listingStatus: string;
  isListed: boolean;
  galleryUrls: string[];
  platforms: PlatformEnum[];
}
