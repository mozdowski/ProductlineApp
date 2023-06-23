export interface ProductForm {
  sku: string;
  name: string;
  brand: string;
  quantity: number;
  price: number;
  category: string;
  condition: number;
  description: string;
  photos: FileList | null;
}
