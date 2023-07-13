import { useContext, useEffect, useState } from 'react';
import { PlatfromsContext } from '../../context/platformsContext';
import { toast } from 'react-toastify';
import { PlatformAuthUrl } from '../../interfaces/platforms/platformsAuthUrlResponse';
import { PlatformEnum } from '../../enums/platform.enum';

export const usePlatforms = () => {
  const platformsContext = useContext(PlatfromsContext);
  const [platforms, setPlatforms] = useState<PlatformAuthUrl[]>([]);
  const [allegroPlatform, setAllegroPlatform] = useState<PlatformAuthUrl>();
  const [ebayPlatform, setEbayPlatform] = useState<PlatformAuthUrl>();

  if (!platformsContext) {
    throw new Error('Could not find platforms context');
  }

  useEffect(() => {
    const fetchData = async () => {
      try {
        const platformsResponse: PlatformAuthUrl[] = await getPlatformsAsync();
        setPlatforms(platformsResponse);
        setAllegroPlatform(
          platformsResponse.find((x) => x.platformName === PlatformEnum.ALLEGRO) as PlatformAuthUrl,
        );
        setEbayPlatform(
          platformsResponse.find((x) => x.platformName === PlatformEnum.EBAY) as PlatformAuthUrl,
        );
      } catch {
        toast.error('Błąd podczas pobierania listy platform');
      }
    };

    fetchData();
  }, []);

  const { getPlatformsAsync } = platformsContext;

  return { platforms, allegroPlatform, ebayPlatform };
};

export {};
