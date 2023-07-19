import { AddedProductResponse } from '../../interfaces/platforms/addedProductResponse';
import { AddProductRequest } from '../../interfaces/products/addProductRequest';
import { GetProductResponse, GetProductsResponse } from '../../interfaces/products/getProductsResponse';
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
}

export { };
