import { OrderStatus } from '../../../../enums/orderStatus.enum';
import './css/notImpementedOrdersButton.css';

function NotImpementedOrdersButton({
  showCompletedOrders,
  handleClickTypeOrdersButton,
  id,
}: {
  showCompletedOrders: boolean;
  handleClickTypeOrdersButton: (showCompleted: boolean) => void;
  id: string;
}) {
  return (
    <div
      id={id}
      className={
        !showCompletedOrders ? 'notImplementedOrdersButton selected' : 'notImplementedOrdersButton'
      }
      onClick={() => handleClickTypeOrdersButton(false)}
    >
      <p>Niezrealizowane</p>
    </div>
  );
}

export default NotImpementedOrdersButton;
