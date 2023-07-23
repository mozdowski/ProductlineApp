import { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import { OrdersRecord } from '../../../../interfaces/orders/OrdersPageInteface';
import { CollapseOrderDetails } from '../bodys/CollapseOrderDetails';
import { OrderStatus } from '../../../../enums/orderStatus.enum';
import BasicTooltip from '../../../atoms/common/tooltip/basicTooltip';

export const OrdersTableRow = ({
  order,
  markOrderAsCompleted,
  onOpenOrderFilesPopup,
  onFilesDownload,
}: {
  order: OrdersRecord;
  markOrderAsCompleted: (orderId: string) => void;
  onOpenOrderFilesPopup: (orderId: string) => void;
  onFilesDownload: (orderId: string) => void;
}) => {
  const [isOpen, setOpenState] = useState<boolean>(false);

  const toggle = useCallback(() => {
    setOpenState((state: boolean) => !state);
  }, [setOpenState]);

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
            <BasicTooltip title="Zarządzaj dokumentami">
              <div
                className="attachOrderFilesButton"
                onClick={() => onOpenOrderFilesPopup(order.orderID)}
              >
                <span className="attachOrderFilesIcon attachFilesIcon" />
              </div>
            </BasicTooltip>

            <BasicTooltip title="Pobierz dokumenty">
              <div
                className="downloadOrderFilesButton"
                onClick={() => onFilesDownload(order.orderID)}
              >
                <span className="downloadOrderFilesIcon downloadFilesIcon" />
              </div>
            </BasicTooltip>


            {order.status === OrderStatus.COMPLETED && (
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
    </React.Fragment>
  );
};
