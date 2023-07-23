import { PlatformAuthUrl } from '../../interfaces/platforms/platformsAuthUrlResponse';
import HttpService from '../common/http.service';

export class PlatformsService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async getPlatformsWithAuthUrls(): Promise<PlatformAuthUrl[]> {
    return this.httpService.get<PlatformAuthUrl[]>('/platforms/auth/url');
  }
}

export {};
