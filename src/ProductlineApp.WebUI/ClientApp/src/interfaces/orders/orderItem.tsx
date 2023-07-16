export interface OrderItem {
  sku: string;
  orderItemId: string;
  name: string;
  unitPrice: number;
  quantity: string;
  deliveryCost: number;
  totalPrice: number;
  fulfillmentStatus: string;
  imageUrl: string;
}
