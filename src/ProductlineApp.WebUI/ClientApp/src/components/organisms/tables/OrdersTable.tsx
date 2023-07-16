import './css/OrdersTable.css';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { OrdersRecord } from '../../../interfaces/orders/OrdersPageInteface';
import { OrdersHederActions } from '../../molecules/table/headersActions/OrdersHederActions';
import { OrdersTableHeader } from '../../molecules/table/headers/OrdersTableHeader';
import { OrdersTableBody } from '../../molecules/table/bodys/OrdersTableBody';

export default function OrdersTable({
  orderRecords,
  showNoImplementedOrders,
  handleClickTypeOrdersButton,
  searchValue,
  onChange
}: {
  orderRecords: OrdersRecord[];
  showNoImplementedOrders: boolean;
  handleClickTypeOrdersButton: any;
  searchValue: string,
  onChange: (e: any) => void
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
        <OrdersTableBody orderRecords={orderRecords} showNoImplementedOrders={"Zakończone"} />
      </table>
      <TableFooter />
    </>
  );
}
