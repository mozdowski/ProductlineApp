import { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import { OrdersRecord } from '../../../../interfaces/orders/OrdersPageInteface';
import { CollapseOrderDetails } from '../bodys/CollapseOrderDetails';
import { OrderStatus } from '../../../../enums/orderStatus.enum';

export const OrdersTableRow = ({
  key,
  order,
  markOrderAsCompleted,
}: {
  order: OrdersRecord;
  key: string | number;
  markOrderAsCompleted: (orderId: string) => void;
}) => {
  const [isOpen, setOpenState] = useState<boolean>(false);

  const toggle = useCallback(() => {
    setOpenState((state: boolean) => !state);
  }, [setOpenState]);

  return (
    <React.Fragment key={key}>
      <tr className="OrdersTableRow">
        <td>
          <CollapseTableButton isOpen={isOpen} toggle={toggle} />
        </td>
        <td>{order.orderID}</td>
        <td>
          {order.orderDate.toLocaleString('default', {
            day: 'numeric',
            month: 'long',
            year: 'numeric',
          })}
        </td>
        <td>
          {order.shipToDate.toLocaleString('default', {
            day: 'numeric',
            month: 'long',
            year: 'numeric',
          })}
        </td>
        <td>{order.client}</td>
        <td>{order.price} zł</td>
        <td>{order.quantity}</td>
        <td className="orderStatus complete">{order.statusText}</td>
        <td>
          <div className="ordersButtonsAction">
            <img className="editOrderIcon" src={EditIcon} />
            {order.status === OrderStatus.COMPLETED ? (
              <div className="assignedOrderButton">
                <span className="assignOrderIcon assignTableIcon" />
              </div>
            ) : (
              ''
            )}
          </div>
        </td>
      </tr>
      {isOpen && (
        <React.Fragment key="details">
          <CollapseOrderDetails
            shippingAddress={order.shippingAddress}
            address={order.shippingAddress.address}
            items={order.items}
          />
        </React.Fragment>
      )}
    </React.Fragment>
  );
};
