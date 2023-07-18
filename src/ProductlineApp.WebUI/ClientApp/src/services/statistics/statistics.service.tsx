import { AuctionsChartData } from '../../interfaces/dashboard/auctionsChartData';
import { MostPopularProductsChartData } from '../../interfaces/dashboard/mostPopularProductsChartData';
import HttpService from '../common/http.service';

export class StatisticsService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async getAuctionsChartData(): Promise<AuctionsChartData> {
    return this.httpService.get<AuctionsChartData>('/statistics/auctions');
  }

  public async getMostPopularProductsChartData(): Promise<MostPopularProductsChartData> {
    return this.httpService.get<MostPopularProductsChartData>('/statistics/mostPopularProducts');
  }
}

export {};
