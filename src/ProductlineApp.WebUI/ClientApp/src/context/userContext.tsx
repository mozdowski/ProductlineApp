import { createContext } from 'react';
import { UserContextProps } from '../interfaces/user/userContextProps';

export const UserContext = createContext<UserContextProps | undefined>(undefined);
