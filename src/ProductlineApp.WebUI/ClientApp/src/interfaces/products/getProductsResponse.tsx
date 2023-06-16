import { Platform } from '../../enums/platform.enum';
import { ProductCondition } from '../../enums/productCondition';

export interface GetProductsResponse {
  products: ProductDtoResponse[];
}

interface ProductDtoResponse {
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
  platforms: Platform[];
}
