import './css/OrdersHederActions.css';
import Searchbar from '../../../atoms/inputs/searchbarInput/Searchbar';
import ImplementedOrdersButton from '../../../atoms/buttons/implementedOrdersButton/ImplementedOrdersButton';
import NotImpementedOrdersButton from '../../../atoms/buttons/notImplementedOrdersButton/NotImplementedOrdersButton';

export const OrdersHederActions = ({
  showCompletedOrders,
  handleClickTypeOrdersButton,
  searchValue,
  onChange,
}: {
  showCompletedOrders: boolean;
  handleClickTypeOrdersButton: (showCompleted: boolean) => void;
  searchValue: string;
  onChange: (e: any) => void;
}) => {
  return (
    <>
      <div className="OrdersTableButtons">
        <div className="changeTypeOrdersButtons">
          <NotImpementedOrdersButton
            showCompletedOrders={showCompletedOrders}
            handleClickTypeOrdersButton={handleClickTypeOrdersButton}
            id={'notImplemented'}
          />
          <ImplementedOrdersButton
            showCompletedOrders={showCompletedOrders}
            handleClickTypeOrdersButton={handleClickTypeOrdersButton}
            id={'implemented'}
          />
        </div>
        <div className="OrdersTableActionButtons">
          <Searchbar searchValue={searchValue} onChange={onChange} />
        </div>
      </div>
    </>
  );
};
