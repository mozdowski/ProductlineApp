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
  showNoImplementedOrders,
  handleClickTypeOrdersButton,
  searchValue,
  onChange,
  markOrderAsCompleted,
}: {
  orderRecords?: OrdersRecord[];
  showNoImplementedOrders: any;
  handleClickTypeOrdersButton: any;
  searchValue: string;
  onChange: (e: any) => void;
  markOrderAsCompleted: (orderId: string) => void;
}) {
  return (
    <>
      <OrdersHederActions
        showNoImplementedOrders={showNoImplementedOrders}
        handleClickTypeOrdersButton={handleClickTypeOrdersButton}
        searchValue={searchValue}
        onChange={onChange}
      />
      <table className="orders">
        <OrdersTableHeader />
        <OrdersTableBody
          orderRecords={orderRecords}
          showNoImplementedOrders={showNoImplementedOrders}
          markOrderAsCompleted={markOrderAsCompleted}
        />
      </table>
      {!orderRecords && <CircularProgress />}
      <TableFooter />
    </>
  );
}
