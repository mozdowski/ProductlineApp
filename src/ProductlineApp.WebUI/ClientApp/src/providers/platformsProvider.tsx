import { ReactNode } from 'react';
import { useAuth } from '../hooks/auth/useAuth';
import { PlatformsService } from '../services/platforms/platforms.service';
import { PlatfromsContext } from '../context/platformsContext';
import { PlatformAuthUrl } from '../interfaces/platforms/platformsAuthUrlResponse';

interface PlatformsProviderProps {
  children: ReactNode;
}

export const PlatformsProvider: React.FC<PlatformsProviderProps> = ({ children }) => {
  const { user } = useAuth();

  const platformsService = new PlatformsService(user?.authToken);

  const getPlatformsAsync = async (): Promise<PlatformAuthUrl[]> => {
    return await platformsService.getPlatformsWithAuthUrls();
  };

  return (
    <PlatfromsContext.Provider value={{ getPlatformsAsync }}>{children}</PlatfromsContext.Provider>
  );
};
