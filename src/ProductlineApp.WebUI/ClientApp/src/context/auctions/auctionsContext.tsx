import { createContext } from 'react';
import { AuctionsContextProps } from '../../interfaces/auctions/auctionsContextProps';

export const AuctionsContext = createContext<AuctionsContextProps | undefined>(undefined);
