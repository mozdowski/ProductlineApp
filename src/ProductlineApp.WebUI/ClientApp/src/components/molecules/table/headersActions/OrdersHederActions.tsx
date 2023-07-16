import React from 'react';
import './css/OrdersHederActions.css';
import Searchbar from '../../../atoms/inputs/searchbarInput/Searchbar';
import ImplementedOrdersButton from '../../../atoms/buttons/implementedOrdersButton/ImplementedOrdersButton';
import NotImpementedOrdersButton from '../../../atoms/buttons/notImplementedOrdersButton/NotImplementedOrdersButton';
import { OrderStatus } from '../../../../enums/orderStatus.enum';

export const OrdersHederActions = ({
  showNoImplementedOrders,
  handleClickTypeOrdersButton,
  searchValue,
  onChange
}: {
  showNoImplementedOrders: any;
  handleClickTypeOrdersButton: any;
  searchValue: string;
  onChange: (e: any) => void
}) => {
  return (
    <>
      <div className="OrdersTableButtons">
        <div className="changeTypeOrdersButtons">
          <NotImpementedOrdersButton
            showNoImplementedOrders={showNoImplementedOrders}
            handleClickTypeOrdersButton={handleClickTypeOrdersButton}
            id={'notImplemented'}
          />
          <ImplementedOrdersButton
            showNoImplementedOrders={showNoImplementedOrders}
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
