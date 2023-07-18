import './css/OrdersTable.css';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { OrdersRecord } from '../../../interfaces/orders/OrdersPageInteface';
import { OrdersHederActions } from '../../molecules/table/headersActions/OrdersHederActions';
import { OrdersTableHeader } from '../../molecules/table/headers/OrdersTableHeader';
import { OrdersTableBody } from '../../molecules/table/bodys/OrdersTableBody';
import { CircularProgress } from '@mui/material';
import { OrderStatus } from '../../../enums/orderStatus.enum';

export default function OrdersTable({
  orderRecords,
  showCompletedOrders,
  handleClickTypeOrdersButton,
  searchValue,
  onChange,
  markOrderAsCompleted,
}: {
  orderRecords?: OrdersRecord[];
  showCompletedOrders: boolean;
  handleClickTypeOrdersButton: (showCompleted: boolean) => void;
  searchValue: string;
  onChange: (e: any) => void;
  markOrderAsCompleted: (orderId: string) => void;
}) {
  return (
    <>
      <OrdersHederActions
        showCompletedOrders={showCompletedOrders}
        handleClickTypeOrdersButton={handleClickTypeOrdersButton}
        searchValue={searchValue}
        onChange={onChange}
      />
      <table className="orders">
        <OrdersTableHeader />
        <OrdersTableBody
          orderRecords={orderRecords}
          showCompletedOrders={showCompletedOrders}
          markOrderAsCompleted={markOrderAsCompleted}
        />
      </table>
      {!orderRecords && <CircularProgress />}
      <TableFooter />
    </>
  );
}
