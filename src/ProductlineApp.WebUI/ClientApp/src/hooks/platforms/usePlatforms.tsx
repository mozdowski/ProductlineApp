import { useContext, useEffect, useState } from 'react';
import { PlatfromsContext } from '../../context/platformsContext';
import { toast } from 'react-toastify';
import { PlatformAuthUrl } from '../../interfaces/platforms/platformsAuthUrlResponse';

export const usePlatforms = () => {
  const platformsContext = useContext(PlatfromsContext);
  const [platforms, setPlatforms] = useState<PlatformAuthUrl[]>([]);

  if (!platformsContext) {
    throw new Error('Could not find platforms context');
  }

  useEffect(() => {
    const fetchData = async () => {
      try {
        const platformsResponse: PlatformAuthUrl[] = await getPlatformsAsync();
        setPlatforms(platformsResponse);
      } catch {
        toast.error('Błąd podczas pobierania listy platform');
      }
    };

    fetchData();
  }, []);

  const { getPlatformsAsync } = platformsContext;

  return { platforms };
};

export {};
