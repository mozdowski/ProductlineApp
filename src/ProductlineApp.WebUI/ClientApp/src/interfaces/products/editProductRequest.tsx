import { ProductCondition } from '../../enums/productCondition';

export interface EditProductRequest {
  sku: string;
  name: string;
  categoryName: string;
  price: number;
  quantity: number;
  imageFile?: File;
  imageUrl?: string;
  brandName: string;
  description: string;
  condition: ProductCondition;
  gallery: string[];
}
