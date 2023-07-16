import { ReactNode } from 'react';
import { useAuth } from '../hooks/auth/useAuth';
import { AuctionsService } from '../services/auctions/auctions.service';
import { AuctionsContext } from '../context/auctions/auctionsContext';

interface AuctionsProviderProps {
  children: ReactNode;
}

export const AuctionsProvider: React.FC<AuctionsProviderProps> = ({ children }) => {
  const { user } = useAuth();

  const auctionsService = new AuctionsService(user?.authToken);

  return (
    <AuctionsContext.Provider value={{ auctionsService }}>{children}</AuctionsContext.Provider>
  );
};
