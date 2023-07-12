import { PlatformAuthUrl } from './platformsAuthUrlResponse';

export interface PlatformsContextProps {
  getPlatformsAsync: () => Promise<PlatformAuthUrl[]>;
}
