import { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import { OrdersRecord } from '../../../../interfaces/orders/OrdersPageInteface';
import { CollapseOrderDetails } from '../bodys/CollapseOrderDetails';
import { OrderStatus } from '../../../../enums/orderStatus.enum';
import BasicTooltip from '../../../atoms/common/tooltip/basicTooltip';
import AddOrderFilesPopup from '../../addOrderFilesPopup/AddOrderFilesPopup';

export const OrdersTableRow = ({
  order,
  markOrderAsCompleted,
}: {
  order: OrdersRecord;
  markOrderAsCompleted: (orderId: string) => void;
}) => {
  const [isOpen, setOpenState] = useState<boolean>(false);

  const toggle = useCallback(() => {
    setOpenState((state: boolean) => !state);
  }, [setOpenState]);

  const [openAddOrderFilesPopup, setOpenAddOrderFilesPopup] = useState(false);

  return (
    <React.Fragment>
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
            <BasicTooltip title="Dodaj lub edytuj dokumenty zamówienia">
              <>
                <div className="attachOrderFilesButton" onClick={() => setOpenAddOrderFilesPopup(true)}>
                  <span className="attachOrderFilesIcon attachFilesIcon" />
                </div>
              </>
            </BasicTooltip>

            <BasicTooltip title="Pobierz dokumenty">
              <div className="downloadOrderFilesButton">
                <span className="downloadOrderFilesIcon downloadFilesIcon" />
              </div>
            </BasicTooltip>
            <img className="editOrderIcon" src={EditIcon} />
            {order.status !== OrderStatus.COMPLETED && (
              <BasicTooltip title="Oznacz jako zrealizowane">
                <div
                  className="assignedOrderButton"
                  onClick={() => markOrderAsCompleted(order.orderID)}
                >
                  <span className="assignOrderIcon assignTableIcon" />
                </div>
              </BasicTooltip>
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
      {openAddOrderFilesPopup && (
        <AddOrderFilesPopup />
      )}
    </React.Fragment>

  );
};
