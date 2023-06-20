import { OrderStatus } from '../../enums/orderStatus.enum';
import { PlatformEnum } from '../../enums/platform.enum';
import { BillingAddress } from './billingAddress';
import { OrderItem } from './orderItem';
import { ShippingAddress } from './shippingAddress';

export interface OrderResponse {
  orderId: string;
  creationDate: Date;
  maxDeliveryDate: Date;
  billingAddress: BillingAddress;
  shippingAddress: ShippingAddress;
  totalPrice: number;
  subtotalPrice: number;
  deliveryCost: number;
  quantity: number;
  status: OrderStatus;
  items: OrderItem[];
  isFulfilled: boolean;
  isPaid: boolean;
  platform: PlatformEnum;
}
