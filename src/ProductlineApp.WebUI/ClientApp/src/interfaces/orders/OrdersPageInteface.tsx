import { OrderStatus } from '../../enums/orderStatus.enum';
import { OrderItem } from './orderItem';
import { ShippingAddress } from './shippingAddress';

export interface OrdersPage {
  orderssTableRecords: OrdersRecord[];
}

export interface OrdersRecord {
  orderID: string;
  orderDate: Date;
  shipToDate: Date;
  client: string;
  price: number;
  quantity: number;
  status: OrderStatus;
  statusText: string;
  shippingAddress: ShippingAddress;
  items: OrderItem[];
}
