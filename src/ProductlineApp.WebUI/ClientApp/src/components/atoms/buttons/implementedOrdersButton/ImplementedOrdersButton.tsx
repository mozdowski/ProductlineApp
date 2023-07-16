import { OrderStatus } from '../../../../enums/orderStatus.enum';
import './css/impementedOrdersButton.css';

function ImpementedOrdersButton({
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
      className={showNoImplementedOrders ? "implementedOrdersButton selected" : "implementedOrdersButton"}
      onClick={handleClickTypeOrdersButton}
    >
      <p>Zrealizowane</p>
    </div>
  );
}

export default ImpementedOrdersButton;
