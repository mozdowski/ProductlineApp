import { PlatformEnum } from '../../enums/platform.enum';
import { ProductCondition } from '../../enums/productCondition';

export interface GetProductsResponse {
  products: ProductDtoResponse[];
}

export interface ProductDtoResponse {
  id: string;
  sku: string;
  name: string;
  category: string;
  price: number;
  quantity: number;
  imageUrl: string;
  brand: string;
  condition: ProductCondition;
  description: string;
  gallery: string[];
  platforms: PlatformEnum[];
}
