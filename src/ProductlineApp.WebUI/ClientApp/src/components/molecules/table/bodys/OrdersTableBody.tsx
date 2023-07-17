import './css/OrdersTableBody.css';
import { OrdersRecord } from '../../../../interfaces/orders/OrdersPageInteface';
import { OrdersTableRow } from '../rows/ordersTableRow';
import { OrderStatus } from '../../../../enums/orderStatus.enum';
import { mapOrderStatusToString } from '../../../../helpers/mappers';

export const OrdersTableBody = ({
  orderRecords,
  showNoImplementedOrders,
  markOrderAsCompleted,
}: {
  orderRecords?: OrdersRecord[];
  showNoImplementedOrders: any;
  markOrderAsCompleted: (orderId: string) => void;
}) => {
  return (
    <>
      <tbody>
        {orderRecords &&
          orderRecords.map((order, key) => (
            <OrdersTableRow key={key} order={order} markOrderAsCompleted={markOrderAsCompleted} />
          ))}
      </tbody>
    </>
  );
};
