import { GetProductsResponse } from '../../interfaces/products/getProductsResponse';
import HttpService from '../common/http.service';

export class ProductsService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async getProductList(): Promise<GetProductsResponse> {
    return this.httpService.get<GetProductsResponse>('/products');
  }
}

export {};
