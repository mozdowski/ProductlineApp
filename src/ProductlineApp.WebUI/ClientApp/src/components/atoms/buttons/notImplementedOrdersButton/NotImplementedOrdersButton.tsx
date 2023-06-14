import './css/notImpementedOrdersButton.css';

function NotImpementedOrdersButton({
  isSelectedTypeOrders,
  handleClickTypeOrdersButton,
  id,
}: {
  isSelectedTypeOrders: any;
  handleClickTypeOrdersButton: any;
  id: string;
}) {
  return (
    <div
      id={id}
      className={
        isSelectedTypeOrders === 'notImplemented'
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
