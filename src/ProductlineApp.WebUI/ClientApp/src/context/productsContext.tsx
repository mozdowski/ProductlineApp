import { createContext } from 'react';
import { ProductContextProps } from '../interfaces/products/productContextProps';

export const ProductsContext = createContext<ProductContextProps | undefined>(undefined);
