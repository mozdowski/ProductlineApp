import { useContext } from 'react';
import { OrdersContext } from '../../context/ordersContext';

export const useOrdersService = () => {
  const ordersContext = useContext(OrdersContext);

  if (!ordersContext) {
    throw new Error('useOrdersService must be used within an OrdersProvider');
  }

  const { ordersService } = ordersContext;

  return { ordersService };
};

export {};
