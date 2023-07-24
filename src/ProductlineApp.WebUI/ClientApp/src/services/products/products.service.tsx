import { AddedProductResponse } from '../../interfaces/platforms/addedProductResponse';
import { AddProductRequest } from '../../interfaces/products/addProductRequest';
import { EditProductRequest } from '../../interfaces/products/editProductRequest';
import {
  GetProductResponse,
  GetProductsResponse,
} from '../../interfaces/products/getProductsResponse';
import HttpService from '../common/http.service';

export class ProductsService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async getProductList(): Promise<GetProductsResponse> {
    return this.httpService.get<GetProductsResponse>('/products');
  }

  public async getProduct(productId: string): Promise<GetProductResponse> {
    return this.httpService.get<GetProductResponse>('/products/' + productId);
  }

  public async addProduct(data: AddProductRequest): Promise<AddedProductResponse> {
    const formData = new FormData();

    Object.entries(data).forEach(([key, value]) => {
      formData.append(key, value);
    });

    return this.httpService.post<AddedProductResponse>('/products/add', formData);
  }

  public async addImageToGallery(productId: string, data: FormData): Promise<void> {
    return this.httpService.post<void>('/products/' + productId + '/addImageToGallery', data);
  }

  public async deleteProduct(productId: string): Promise<void> {
    return this.httpService.delete<void>('/products/' + productId);
  }

  public async updateProduct(productId: string, data: EditProductRequest): Promise<void> {
    const formData = new FormData();

    Object.entries(data).forEach(([key, value]) => {
      if (key === 'gallery') {
        return;
      }
      formData.append(key, value);
    });

    for (let i = 0; i < data.gallery.length; i++) {
      formData.append(`gallery[${i}]`, data.gallery[i]);
    }

    return this.httpService.post<void>(`/products/${productId}/updateInfo`, formData);
  }
}

export {};
