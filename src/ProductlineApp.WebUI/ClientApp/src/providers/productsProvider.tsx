import { ReactNode } from 'react';
import { ProductsService } from '../services/products/products.service';
import { useAuth } from '../hooks/auth/useAuth';
import { ProductsContext } from '../context/productsContext';

interface ProductsProviderProps {
  children: ReactNode;
}

export const ProductsProvider: React.FC<ProductsProviderProps> = ({ children }) => {
  const { user } = useAuth();

  const productsService = new ProductsService(user?.authToken);

  return (
    <ProductsContext.Provider value={{ productsService }}>{children}</ProductsContext.Provider>
  );
};
