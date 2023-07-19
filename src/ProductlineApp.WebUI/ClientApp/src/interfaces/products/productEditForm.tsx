import { ProductForm } from './productForm';

export interface ProductEditForm extends ProductForm {
  gallery: string[];
}
