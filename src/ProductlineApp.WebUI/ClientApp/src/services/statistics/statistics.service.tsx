import { AuctionsChartData } from '../../interfaces/dashboard/auctionsChartData';
import { MostPopularProductsChartData } from '../../interfaces/dashboard/mostPopularProductsChartData';
import { SoldTodayChartData } from '../../interfaces/dashboard/soldTodayChartData';
import { WeeklySellsChartData } from '../../interfaces/dashboard/weeklySellsChartData';
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

  public async getSoldTodayProductsChartData(): Promise<SoldTodayChartData> {
    return this.httpService.get<SoldTodayChartData>('/statistics/soldToday');
  }

  public async getWeeklySellingStatsChartData(): Promise<WeeklySellsChartData> {
    return this.httpService.get<WeeklySellsChartData>('/statistics/weeklySelling');
  }
}

export {};
