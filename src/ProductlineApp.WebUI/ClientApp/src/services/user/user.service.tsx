import { GainAccessTokenRequest } from '../../interfaces/platforms/gainAccessTokenRequest';
import { ChangePasswordRequest } from '../../interfaces/user/changePasswordRequest';
import { DisconnectPlatformRequest } from '../../interfaces/user/disconnectPlatformRequest';
import { UpdateAvatarResponse } from '../../interfaces/user/updateAvatarResponse';
import HttpService from '../common/http.service';

export class UserService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async gainAccessToken(platformId: string, data: GainAccessTokenRequest): Promise<void> {
    return this.httpService.post<void>('/platforms/auth/gainToken/' + platformId, data);
  }

  public async getUserConnections(): Promise<string[]> {
    return this.httpService.get<string[]>('/user/platformConnections');
  }

  public async disconnectPlatformConnection(data: DisconnectPlatformRequest): Promise<void> {
    return this.httpService.post<void>('/user/disconnectPlatform', data);
  }

  public async changePassword(data: ChangePasswordRequest): Promise<void> {
    return this.httpService.post<void>('/user/changePassword', data);
  }

  public async updateAvatar(data: FormData): Promise<UpdateAvatarResponse> {
    return this.httpService.post<UpdateAvatarResponse>('/user/updateAvatar', data);
  }
}

export {};
