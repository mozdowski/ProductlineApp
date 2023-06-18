import { GetAuctionsResponse } from '../../interfaces/auctions/getAuctionsResponse';
import { GetPlatformsResponse } from '../../interfaces/platforms/getPlatformsResponse';
import HttpService from '../common/http.service';

export class AuctionsService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async getPlatformAuctionsList(platformId: string): Promise<GetAuctionsResponse> {
    return this.httpService.get<GetAuctionsResponse>('/platforms/listings/' + platformId);
  }

  public async getPlatformsWithListings(): Promise<GetPlatformsResponse> {
    return this.httpService.get<GetPlatformsResponse>('/listings/getPlatformsWithListings');
  }
}

export {};
