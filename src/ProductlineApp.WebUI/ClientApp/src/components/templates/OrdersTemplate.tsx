import './css/OrdersTemplate.css';
import { OrdersRecord } from '../../interfaces/orders/OrdersPageInteface';
import OrdersPageHeader from '../organisms/pageHeaders/OrdersPageHeader';
import OrdersTable from '../organisms/tables/OrdersTable';
import { OrderStatus } from '../../enums/orderStatus.enum';

export default function OrdersTemplate({
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
      <OrdersPageHeader />
      <div className="content">
        <div className="tableOrders">
          <OrdersTable
            orderRecords={orderRecords}
            showCompletedOrders={showCompletedOrders}
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
