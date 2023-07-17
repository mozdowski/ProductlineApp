import './css/OrdersTemplate.css';
import { OrdersRecord } from '../../interfaces/orders/OrdersPageInteface';
import OrdersPageHeader from '../organisms/pageHeaders/OrdersPageHeader';
import OrdersTable from '../organisms/tables/OrdersTable';
import { OrderStatus } from '../../enums/orderStatus.enum';

export default function OrdersTemplate({
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
      <OrdersPageHeader />
      <div className="content">
        <div className="tableOrders">
          <OrdersTable
            orderRecords={orderRecords}
            showNoImplementedOrders={showNoImplementedOrders}
            handleClickTypeOrdersButton={handleClickTypeOrdersButton}
            searchValue={searchValue}
            onChange={onChange}
            markOrderAsCompleted={markOrderAsCompleted}
          />
        </div>
      </div>
    </>
  );
}
