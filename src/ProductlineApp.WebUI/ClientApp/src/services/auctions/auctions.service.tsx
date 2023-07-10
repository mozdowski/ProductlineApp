import { AllegroUserPoliciesResponse } from '../../interfaces/auctions/allegroUserPoliciesResponse';
import { GetAuctionsResponse } from '../../interfaces/auctions/getAuctionsResponse';
import { AllegroProductParametersResponse } from '../../interfaces/platforms/allegroProductParametersResponse';
import { GetAllegroCatalogueProductDetailsResponse } from '../../interfaces/platforms/getAllegroCatalogueProductDetailsResponse';
import { GetAllegroCalalogueResponse } from '../../interfaces/platforms/getAllegroCatalogueResponse';
import { GetPlatformsResponse } from '../../interfaces/platforms/getPlatformsResponse';
import { GetProductsResponse } from '../../interfaces/products/getProductsResponse';
import HttpService from '../common/http.service';

export class AuctionsService {
  private httpService: HttpService;

  constructor(token: string | undefined) {
    this.httpService = new HttpService(token);
  }

  public async getProductList(): Promise<GetProductsResponse> {
    return this.httpService.get<GetProductsResponse>('/products');
  }

  public async getPlatformAuctionsList(platformId: string): Promise<GetAuctionsResponse> {
    return this.httpService.get<GetAuctionsResponse>('/platforms/listings/' + platformId);
  }

  public async getPlatformsWithListings(): Promise<GetPlatformsResponse> {
    return this.httpService.get<GetPlatformsResponse>('/listings/getPlatformsWithListings');
  }

  public async getPlatforms(): Promise<GetPlatformsResponse> {
    return this.httpService.get<GetPlatformsResponse>('/platforms/getAllAvailable');
  }

  public async getAllegoProductCatalogueByPhrase(phrase: string) {
    return this.httpService.get<GetAllegroCalalogueResponse>(
      '/allegro/productList?phrase=' + phrase,
    );
  }

  public async getAllegoCatalogueProductDetails(id: string) {
    return this.httpService.get<GetAllegroCatalogueProductDetailsResponse>(
      '/allegro/product/' + id,
    );
  }

  public async getAllegoParametersByCategory(categoryId: string) {
    return this.httpService.get<AllegroProductParametersResponse>(
      '/allegro/product/categoryParameters/' + categoryId,
    );
  }

  public async getAllegoUserPolicies() {
    return this.httpService.get<AllegroUserPoliciesResponse>('/allegro/userPolicies');
  }
}

export {};
