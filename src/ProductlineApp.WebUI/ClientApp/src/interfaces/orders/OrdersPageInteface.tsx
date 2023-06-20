import { OrderStatus } from '../../enums/orderStatus.enum';

export interface OrdersPage {
  orderssTableRecords: OrdersRecord[];
}

export interface OrdersRecord {
  OrderID: string;
  OrderDate: Date;
  ShipToDate: Date;
  Client: string;
  Price: number;
  Quantity: number;
  Status: string;
}
