import './css/impementedOrdersButton.css';

function ImpementedOrdersButton({
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
        showCompletedOrders ? 'implementedOrdersButton selected' : 'implementedOrdersButton'
      }
      onClick={() => handleClickTypeOrdersButton(true)}
    >
      <p>Zrealizowane</p>
    </div>
  );
}

export default ImpementedOrdersButton;
