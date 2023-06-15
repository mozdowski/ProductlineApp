export interface GetProductsResponse {
  products: ProductDtoResponse[];
}

interface ProductDtoResponse {
  name: string;
  category: Category;
  price: number;
  quantity: number;
  image: Image;
  brand: Brand;
  description: string;
  gallery: Image[];
}

interface Category {
  name: string;
}

interface Image {
  name: string;
  url: string;
}

interface Brand {
  name: string;
}
