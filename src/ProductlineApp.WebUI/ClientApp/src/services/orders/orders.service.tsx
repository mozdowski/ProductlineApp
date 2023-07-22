import { GetAllOrdersResponse } from '../../interfaces/orders/getAllOrdersResponse';
import { OrderDocumentsResponse } from '../../interfaces/orders/orderDocumentsResponse';
import { UpdateOrderDocumentsRequest } from '../../interfaces/orders/updateOrderDocumentsRequest';
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

  public async getOrderDocuments(orderId: string): Promise<OrderDocumentsResponse> {
    return this.httpService.get<OrderDocumentsResponse>(`/orders/${orderId}/documents`);
  }

  public async attachDocumentToOrder(
    orderId: string,
    data: FormData,
  ): Promise<OrderDocumentsResponse> {
    return this.httpService.post<OrderDocumentsResponse>(`/orders/${orderId}/attachDocument`, data);
  }

  public async updateOrderDocuments(
    orderId: string,
    data: UpdateOrderDocumentsRequest,
  ): Promise<void> {
    return this.httpService.post<void>(`/orders/${orderId}/updateExistingDocuments`, data);
  }
}

export {};
