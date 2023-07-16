import './css/OrdersTableBody.css';
import { OrdersRecord } from '../../../../interfaces/orders/OrdersPageInteface';
import { OrdersTableRow } from '../rows/ordersTableRow';

export const OrdersTableBody = ({ orderRecords, showNoImplementedOrders }: { orderRecords: OrdersRecord[], showNoImplementedOrders: boolean }) => {

  return (
    <>
      <tbody>
        {orderRecords.map((order, key) => (
          <OrdersTableRow key={key} order={order} />
        ))}
      </tbody>
    </>
  );
};
