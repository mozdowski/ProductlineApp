import { createContext } from 'react';
import { AddAuctionContextProps } from '../../interfaces/auctions/addAuctionContextProps';

export const AddAuctionContext = createContext<AddAuctionContextProps | undefined>(undefined);
