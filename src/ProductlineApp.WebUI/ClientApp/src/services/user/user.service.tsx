import { GainAccessTokenRequest } from '../../interfaces/platforms/gainAccessTokenRequest';
import { PlatformAuthUrl } from '../../interfaces/platforms/platformsAuthUrlResponse';
import HttpService from '../common/http.service';

export class UserService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async gainAccessToken(platformId: string, data: GainAccessTokenRequest): Promise<void> {
    return this.httpService.put<void>('/platforms/auth/gainToken/' + platformId, data);
  }

  public async getUserConnections(): Promise<string[]> {
    return this.httpService.get<string[]>('/user/platformConnections');
  }
}

export {};
