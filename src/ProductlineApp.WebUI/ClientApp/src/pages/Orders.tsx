import { useEffect, useState } from 'react';
import OrdersTemplate from '../components/templates/OrdersTemplate';
import { OrdersRecord } from '../interfaces/orders/OrdersPageInteface';
import { useOrdersService } from '../hooks/orders/useOrdersService';
import { mapOrderStatusToString } from '../helpers/mappers';
import { toast } from 'react-toastify';

export default function Orders() {
  const [showCompletedOrders, setShowCompletedOrders] = useState<boolean>(false);
  const [searchValue, setSearchValue] = useState('');
  const [orders, setOrders] = useState<OrdersRecord[] | undefined>(undefined);
  const { ordersService } = useOrdersService();
  const [refreshRecords, setRefreshRecords] = useState<boolean>(false);

  const handleClickTypeOrdersButton = (showCompleted: boolean) => {
    setShowCompletedOrders(showCompleted);
    setRefreshRecords(!refreshRecords);
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
    setShowCompletedOrders(false);
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
    setOrders(undefined);
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
  }, [refreshRecords]);

  return (
    <OrdersTemplate
      orderRecords={searchOrders}
      handleClickTypeOrdersButton={handleClickTypeOrdersButton}
      searchValue={searchValue}
      onChange={searchTableOrders}
      showCompletedOrders={showCompletedOrders}
      markOrderAsCompleted={handleMarkOrderAsCompleted}
    />
  );
}
