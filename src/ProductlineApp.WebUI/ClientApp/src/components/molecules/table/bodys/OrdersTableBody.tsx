import './css/OrdersTableBody.css';
import { OrdersRecord } from '../../../../interfaces/orders/OrdersPageInteface';
import { OrdersTableRow } from '../rows/ordersTableRow';
import { OrderStatus } from '../../../../enums/orderStatus.enum';
import { mapOrderStatusToString } from '../../../../helpers/mappers';

export const OrdersTableBody = ({
  orderRecords,
  showCompletedOrders,
  page,
  rowsPerPage,
  markOrderAsCompleted,
  onOpenOrderFilesPopup,
  onFilesDownload,
}: {
  orderRecords?: OrdersRecord[];
  showCompletedOrders: boolean;
  page: number;
  rowsPerPage: number;
  markOrderAsCompleted: (orderId: string) => void;
  onOpenOrderFilesPopup: (orderId: string) => void;
  onFilesDownload: (orderId: string) => void;
}) => {
  return (
    <>
      <tbody>
        {orderRecords &&
          orderRecords
            .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
            .map(
              (order, key) =>
                order &&
                showCompletedOrders === (order.status === OrderStatus.COMPLETED) && (
                  <OrdersTableRow
                    key={key}
                    order={order}
                    markOrderAsCompleted={markOrderAsCompleted}
                    onOpenOrderFilesPopup={onOpenOrderFilesPopup}
                    onFilesDownload={onFilesDownload}
                  />
                ),
            )}
      </tbody>
    </>
  );
};
