import { ProductCondition } from '../../enums/productCondition';

export interface AddProductRequest {
  sku: string;
  name: string;
  categoryName: string;
  price: number;
  quantity: number;
  image: File;
  brandName: string;
  description: string;
  condition: ProductCondition;
}
