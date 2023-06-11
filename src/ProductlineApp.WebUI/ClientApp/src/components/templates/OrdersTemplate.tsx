import './css/OrdersTemplate.css';
import { OrdersRecord } from "../../interfaces/orders/OrdersPageInteface";
import OrdersPageHeader from '../organisms/pageHeaders/OrdersPageHeader';
import OrdersTable from '../organisms/tables/OrdersTable';

export default function OrdersTemplate({ orderRecords, isSelectedTypeOrders, handleClickTypeOrdersButton }: { orderRecords: OrdersRecord[], isSelectedTypeOrders: any, handleClickTypeOrdersButton: any }) {
    return (
        <>
            <OrdersPageHeader />
            <div className="content">
                <div className="tableOrders">
                    <OrdersTable orderRecords={orderRecords} isSelectedTypeOrders={isSelectedTypeOrders} handleClickTypeOrdersButton={handleClickTypeOrdersButton} />
                </div>
            </div>
        </>
    );
}