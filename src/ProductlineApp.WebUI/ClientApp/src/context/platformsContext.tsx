import { createContext } from 'react';
import { PlatformsContextProps } from '../interfaces/platforms/platformsContextProps';

export const PlatfromsContext = createContext<PlatformsContextProps | undefined>(undefined);
