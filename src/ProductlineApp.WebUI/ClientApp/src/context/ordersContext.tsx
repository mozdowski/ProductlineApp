import { createContext } from 'react';
import { OrdersContextProps } from '../interfaces/orders/ordersContextProps';

export const OrdersContext = createContext<OrdersContextProps | undefined>(undefined);

export {};
