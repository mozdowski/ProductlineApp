import React, { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import { CollapseOrderDetails } from './CollapseOrderDetails';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import './css/OrdersTableBody.css';
import { OrdersRecord } from '../../../../interfaces/orders/OrdersPageInteface';

export default function openCollapse(init: any) {
  const [isOpen, setOpenState] = useState(init);

  const toggle = useCallback(() => {
    setOpenState((state: any) => !state);
  }, [setOpenState]);

  return { isOpen, toggle };
}

export const OrdersTableBody = ({ orderRecords }: { orderRecords: OrdersRecord[] }) => {
  const { isOpen, toggle } = openCollapse(false);

  return (
    <>
      <tbody>
        <tr className="OrdersTableRow">
          <td>
            <CollapseTableButton isOpen={isOpen} toggle={toggle} />
          </td>
          {orderRecords.map((order, key) => (
            <React.Fragment key={key}>
              <td>{order.OrderID}</td>
              <td>{order.OrderDate.toLocaleDateString()}</td>
              <td>{order.ShipToDate.toLocaleDateString()}</td>
              <td>{order.Client}</td>
              <td>{order.Price} zł</td>
              <td>{order.Quantity}</td>
              <td className="orderStatus complete">{order.Status}</td>
            </React.Fragment>
          ))}
          <td>
            <div className="ordersButtonsAction">
              <img className="editOrderIcon" src={EditIcon} />
            </div>
          </td>
        </tr>
        {isOpen && <CollapseOrderDetails isOpen={isOpen} orderRecords={orderRecords} />}
      </tbody>
    </>
  );
};
