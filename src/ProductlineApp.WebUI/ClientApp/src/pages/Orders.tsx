import { useEffect, useState } from 'react';
import OrdersTemplate from '../components/templates/OrdersTemplate';
import { OrdersRecord } from '../interfaces/orders/OrdersPageInteface';
import { useOrdersService } from '../hooks/orders/useOrdersService';
import { mapOrderStatusToString } from '../helpers/mappers';

export default function Orders() {
  const [isSelectedTypeOrders, SetisSelectedTypeOrders] = useState('');
  const handleClickTypeOrdersButton = (e: any) => {
    SetisSelectedTypeOrders(e.target.id);
  };

  const [orders, setOrders] = useState<OrdersRecord[]>([]);
  const { ordersService } = useOrdersService();

  useEffect(() => {
    ordersService.getOrdersList().then((res) => {
      const orderRecords: OrdersRecord[] = res.orders.map((order) => ({
        orderID: order.orderId,
        orderDate: new Date(order.creationDate),
        shipToDate: new Date(order.maxDeliveryDate as Date),
        client: order.billingAddress.firstName + ' ' + order.billingAddress.lastName,
        price: order.totalPrice,
        quantity: order.quantity,
        status: mapOrderStatusToString(order.status),
        shippingAddress: order.shippingAddress,
        items: order.items
      }));
      setOrders(orderRecords);
    });
  }, []);

  return (
    <OrdersTemplate
      orderRecords={orders}
      isSelectedTypeOrders={isSelectedTypeOrders}
      handleClickTypeOrdersButton={handleClickTypeOrdersButton}
    />
  );
}
