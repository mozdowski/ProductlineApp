import { useState } from 'react';
import OrdersTemplate from '../components/templates/OrdersTemplate';

export default function Orders() {
  const [isSelectedTypeOrders, SetisSelectedTypeOrders] = useState('');
  const handleClickTypeOrdersButton = (e: any) => {
    SetisSelectedTypeOrders(e.target.id);
  };

  return (
    <OrdersTemplate
      orderRecords={[]}
      isSelectedTypeOrders={isSelectedTypeOrders}
      handleClickTypeOrdersButton={handleClickTypeOrdersButton}
    />
  );
}
