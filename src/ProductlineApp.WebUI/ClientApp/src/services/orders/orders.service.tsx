import { GetAllOrdersResponse } from '../../interfaces/orders/getAllOrdersResponse';
import HttpService from '../common/http.service';

export class OrdersService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async getOrdersList(): Promise<GetAllOrdersResponse> {
    return this.httpService.get<GetAllOrdersResponse>('/orders');
  }

  public async markOrderAsCompleted(orderId: string): Promise<void> {
    return this.httpService.post<void>(`/orders/markCompleted/${orderId}`);
  }
}

export {};
