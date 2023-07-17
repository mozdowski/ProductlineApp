import { OrderStatus } from '../../../../enums/orderStatus.enum';
import './css/notImpementedOrdersButton.css';

function NotImpementedOrdersButton({
  showNoImplementedOrders,
  handleClickTypeOrdersButton,
  id,
}: {
  showNoImplementedOrders: any;
  handleClickTypeOrdersButton: any;
  id: string;
}) {
  return (
    <div
      id={id}
      className={
        showNoImplementedOrders
          ? 'notImplementedOrdersButton selected'
          : 'notImplementedOrdersButton'
      }
      onClick={handleClickTypeOrdersButton}
    >
      <p>Niezrealizowane</p>
    </div>
  );
}

export default NotImpementedOrdersButton;
