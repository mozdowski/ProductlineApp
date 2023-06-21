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
        OrderID: order.orderId,
        OrderDate: new Date(order.creationDate),
        ShipToDate: new Date(order.maxDeliveryDate as Date),
        Client: order.billingAddress.firstName + ' ' + order.billingAddress.lastName,
        Price: order.totalPrice,
        Quantity: order.quantity,
        Status: mapOrderStatusToString(order.status),
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
