import React from 'react';
import './css/OrdersHederActions.css';
import Searchbar from '../../../atoms/inputs/searchbarInput/Searchbar';
import ImplementedOrdersButton from '../../../atoms/buttons/implementedOrdersButton/ImplementedOrdersButton';
import NotImpementedOrdersButton from '../../../atoms/buttons/notImplementedOrdersButton/NotImplementedOrdersButton';

export const OrdersHederActions = ({
  isSelectedTypeOrders,
  handleClickTypeOrdersButton,
}: {
  isSelectedTypeOrders: any;
  handleClickTypeOrdersButton: any;
}) => {
  return (
    <>
      <div className="OrdersTableButtons">
        <div className="changeTypeOrdersButtons">
          <ImplementedOrdersButton
            isSelectedTypeOrders={isSelectedTypeOrders}
            handleClickTypeOrdersButton={handleClickTypeOrdersButton}
            id={'implemented'}
          />
          <NotImpementedOrdersButton
            isSelectedTypeOrders={isSelectedTypeOrders}
            handleClickTypeOrdersButton={handleClickTypeOrdersButton}
            id={'notImplemented'}
          />
        </div>
        <div className="OrdersTableActionButtons">
          <Searchbar />
        </div>
      </div>
    </>
  );
};
