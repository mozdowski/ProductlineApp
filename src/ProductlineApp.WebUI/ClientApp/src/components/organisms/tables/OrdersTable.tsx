import './css/OrdersTable.css';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { OrdersRecord } from '../../../interfaces/orders/OrdersPageInteface';
import { OrdersHederActions } from '../../molecules/table/headersActions/OrdersHederActions';
import { OrdersTableHeader } from '../../molecules/table/headers/OrdersTableHeader';
import { OrdersTableBody } from '../../molecules/table/bodys/OrdersTableBody';

export default function OrdersTable({
  orderRecords,
  isSelectedTypeOrders,
  handleClickTypeOrdersButton,
}: {
  orderRecords: OrdersRecord[];
  isSelectedTypeOrders: any;
  handleClickTypeOrdersButton: any;
}) {
  return (
    <>
      <OrdersHederActions
        isSelectedTypeOrders={isSelectedTypeOrders}
        handleClickTypeOrdersButton={handleClickTypeOrdersButton}
      />
      <table className="orders">
        <OrdersTableHeader />
        <OrdersTableBody orderRecords={orderRecords} />
      </table>
      <TableFooter />
    </>
  );
}
