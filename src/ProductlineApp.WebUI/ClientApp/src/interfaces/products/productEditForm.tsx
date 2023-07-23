import { Photo } from '../../pages/EditProduct';

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
