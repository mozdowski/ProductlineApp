export interface OrdersPage {
  orderssTableRecords: OrdersRecord[];
}

export interface OrdersRecord {
  OrderID: number;
  OrderDate: string;
  ShipToDate: string;
  Client: string;
  Price: number;
  Quantity: number;
  Status: string;
}
