import { PlatformEnum } from '../../enums/platform.enum';

export interface PlatformAuthUrl {
  platformId: string;
  platformName: PlatformEnum;
  authUrl: string;
}
