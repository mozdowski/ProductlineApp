import { ReactNode } from 'react';
import { useAuth } from '../hooks/auth/useAuth';
import { OrdersService } from '../services/orders/orders.service';
import { OrdersContext } from '../context/ordersContext';

interface OrdersProviderProps {
  children: ReactNode;
}

export const OrdersProvider: React.FC<OrdersProviderProps> = ({ children }) => {
  const { user } = useAuth();

  const ordersService = new OrdersService(user?.authToken);

  return <OrdersContext.Provider value={{ ordersService }}>{children}</OrdersContext.Provider>;
};
