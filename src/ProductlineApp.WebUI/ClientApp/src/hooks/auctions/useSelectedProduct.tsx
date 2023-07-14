import { useContext } from 'react';
import { AddAuctionContext } from '../../context/auctions/addAuctionContext';

export const useSelectedProduct = () => {
  const addAuctionsContext = useContext(AddAuctionContext);

  if (!addAuctionsContext) {
    throw new Error('useSelectedProduct must be used within an AddAuction component');
  }

  const { selectedProduct, setSelectedProduct } = addAuctionsContext;

  return { selectedProduct, setSelectedProduct };
};

export {};
