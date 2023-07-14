import { ReactNode, useState } from 'react';
import { ProductAuctionData } from '../interfaces/products/getProductsSKU';
import { AddAuctionContext } from '../context/auctions/addAuctionContext';

interface AddAuctionProviderProps {
  children: ReactNode;
}

export const AddAuctionProvider: React.FC<AddAuctionProviderProps> = ({ children }) => {
  const [selectedProduct, setSelectedProduct] = useState<ProductAuctionData>({
    id: '',
    imageUrls: [],
    sku: '',
    brand: '',
    name: '',
    condition: 0,
    quantity: 0,
    price: 0,
    description: '',
  });

  return (
    <AddAuctionContext.Provider value={{ selectedProduct, setSelectedProduct }}>
      {children}
    </AddAuctionContext.Provider>
  );
};
