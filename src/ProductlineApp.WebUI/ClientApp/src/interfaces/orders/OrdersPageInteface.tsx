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
  status: string;
  shippingAddress: ShippingAddress;
  items: OrderItem[];
}