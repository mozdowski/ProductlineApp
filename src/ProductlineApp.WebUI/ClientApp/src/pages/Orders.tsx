import { useEffect, useState } from 'react';
import OrdersTemplate from '../components/templates/OrdersTemplate';
import { OrdersRecord } from '../interfaces/orders/OrdersPageInteface';
import { useOrdersService } from '../hooks/orders/useOrdersService';
import { mapOrderStatusToString } from '../helpers/mappers';
import { toast } from 'react-toastify';

export default function Orders() {
  const [showNoImplementedOrders, setShowNoImplementedOrders] = useState<boolean>();
  const [searchValue, setSearchValue] = useState('');
  const [orders, setOrders] = useState<OrdersRecord[] | undefined>(undefined);
  const { ordersService } = useOrdersService();

  const handleClickTypeOrdersButton = (e: any) => {
    const setNoImplemented = e.target.value == 'notImplemented';
    setShowNoImplementedOrders(setNoImplemented);
  };

  const searchTableOrders = (e: { target: { value: React.SetStateAction<string> } }) => {
    setSearchValue(e.target.value);
  };

  const handleMarkOrderAsCompleted = async (orderId: string) => {
    try {
      const res = await ordersService.markOrderAsCompleted(orderId);
      toast.success('Zamówienie zrealizowane');
    } catch {
      toast.error('Błąd podczas zamykania zamówiena');
    }
  };

  const searchOrders = orders
    ? orders.filter((order) => {
        return (
          order.orderID.toLowerCase().indexOf(searchValue) >= 0 ||
          order.orderDate.getDate().toString().indexOf(searchValue) >= 0 ||
          order.shipToDate.getDate().toString().indexOf(searchValue) >= 0 ||
          order.client.toLowerCase().indexOf(searchValue) >= 0 ||
          order.price.toString().toLowerCase().indexOf(searchValue) >= 0 ||
          order.quantity.toString().toLowerCase().indexOf(searchValue) >= 0 ||
          order.statusText.indexOf(searchValue) >= 0
        );
      })
    : undefined;

  useEffect(() => {
    ordersService.getOrdersList().then((res) => {
      const orderRecords: OrdersRecord[] = res.orders.map((order) => ({
        orderID: order.orderId,
        orderDate: new Date(order.creationDate),
        shipToDate: new Date(order.maxDeliveryDate as Date),
        client: order.billingAddress.firstName + ' ' + order.billingAddress.lastName,
        price: order.totalPrice,
        quantity: order.quantity,
        statusText: mapOrderStatusToString(order.status),
        status: order.status,
        shippingAddress: order.shippingAddress,
        items: order.items,
      }));
      setOrders(orderRecords);
    });
  }, [searchValue]);

  return (
    <OrdersTemplate
      orderRecords={searchOrders}
      handleClickTypeOrdersButton={handleClickTypeOrdersButton}
      searchValue={searchValue}
      onChange={searchTableOrders}
      showNoImplementedOrders={showNoImplementedOrders}
      markOrderAsCompleted={handleMarkOrderAsCompleted}
    />
  );
}
