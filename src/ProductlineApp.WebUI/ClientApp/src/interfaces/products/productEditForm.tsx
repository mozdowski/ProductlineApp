import { Photo } from '../../pages/EditProduct';
import { ProductForm } from './productForm';

export interface ProductEditForm {
  sku: string;
  name: string;
  brand: string;
  quantity: number;
  price: number;
  category: string;
  condition: number;
  description: string;
  photos: Photo[];
}
