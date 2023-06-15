import { useContext } from 'react';
import { ProductsContext } from '../../context/productsContext';

export const useProductsService = () => {
  const productContext = useContext(ProductsContext);

  if (!productContext) {
    throw new Error('useAuth must be used within an AuthProvider');
  }

  const { productsService } = productContext;

  return { productsService };
};

export {};
