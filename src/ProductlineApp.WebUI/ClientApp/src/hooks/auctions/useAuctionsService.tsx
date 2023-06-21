import { useContext } from 'react';
import { AuctionsContext } from '../../context/auctionsContext';

export const useAuctionsService = () => {
  const auctionsContext = useContext(AuctionsContext);

  if (!auctionsContext) {
    throw new Error('useAuctionsService must be used within an AuthProvider');
  }

  const { auctionsService } = auctionsContext;

  return { auctionsService };
};

export {};
