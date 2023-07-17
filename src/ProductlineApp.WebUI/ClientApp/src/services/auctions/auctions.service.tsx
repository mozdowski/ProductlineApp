import { AllegroAuctionRenewalRequest } from '../../interfaces/auctions/allegroAuctionRenewalRequest';
import { AllegroOfferProductDetailsResponse } from '../../interfaces/auctions/allegroOfferProductDetailsResponse';
import { AllegroUserPoliciesResponse } from '../../interfaces/auctions/allegroUserPoliciesResponse';
import { CreateAllegroAuction } from '../../interfaces/auctions/createAllegroAuction';
import { CreateEbayAuctionRequest } from '../../interfaces/auctions/createEbayAuctionRequest';
import { CreateListingTemplateRequest } from '../../interfaces/auctions/createListingTemplateRequest';
import { CreateListingTemplateResponse } from '../../interfaces/auctions/createListingTemplateResponse';
import { EbayAuctionDetailsResponse } from '../../interfaces/auctions/ebayAuctionDetailsResponse';
import { EbayCategoryAspectsResponse } from '../../interfaces/auctions/ebayCategoryAspectsResponse';
import { EbayCategoryTreeResponse } from '../../interfaces/auctions/ebayCategoryTreeResponse';
import { EbayUserPoliciesResponse } from '../../interfaces/auctions/ebayUserPoliciesResponse';
import { GetAuctionsResponse } from '../../interfaces/auctions/getAuctionsResponse';
import { WithdrawAuctionRequest } from '../../interfaces/auctions/withdrawAuctionRequest';
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

  public async getProductsForAution(): Promise<GetProductsResponse> {
    return this.httpService.get<GetProductsResponse>('/products');
  }

  public async createListingTemplate(
    data: CreateListingTemplateRequest,
  ): Promise<CreateListingTemplateResponse> {
    return this.httpService.post<CreateListingTemplateResponse>('/listings/createTemplate', data);
  }

  public async createAllegroListing(data: CreateAllegroAuction): Promise<void> {
    return this.httpService.post<void>('/allegro/createListing', data);
  }

  public async getPlatformConnections(): Promise<string[]> {
    return this.httpService.get<string[]>('/user/platformConnections');
  }

  public async getAllegroOfferProductDetails(
    offerId: string,
  ): Promise<AllegroOfferProductDetailsResponse> {
    return this.httpService.get<AllegroOfferProductDetailsResponse>(
      '/allegro/offerProductDetails/' + offerId,
    );
  }

  public async updateAllegroAuction(offerId: string, data: CreateAllegroAuction): Promise<void> {
    return this.httpService.post<void>('/allegro/updateListing/' + offerId, data);
  }

  public async withdrawAuction(platformId: string, data: WithdrawAuctionRequest): Promise<void> {
    return this.httpService.post<void>(`/platforms/withdrawListing/${platformId}`, data);
  }

  public async allegroAuctionRenewal(data: AllegroAuctionRenewalRequest): Promise<void> {
    return this.httpService.post<void>('/allegro/listingRenewal', data);
  }

  public async getEbayCategoryTree(): Promise<EbayCategoryTreeResponse> {
    return this.httpService.get<EbayCategoryTreeResponse>('/ebay/categories/tree');
  }

  public async getEbayCategoryAspects(categoryId: string): Promise<EbayCategoryAspectsResponse> {
    return this.httpService.get<EbayCategoryAspectsResponse>(
      `/ebay/aspectsForCategory/${categoryId}`,
    );
  }

  public async getEbayUserPolicies(): Promise<EbayUserPoliciesResponse> {
    return this.httpService.get<EbayUserPoliciesResponse>('/ebay/userPolicies');
  }

  public async createEbayListing(data: CreateEbayAuctionRequest): Promise<void> {
    return this.httpService.post<void>('/ebay/createListing', data);
  }

  public async withdrawEbayAuction(data: WithdrawAuctionRequest): Promise<void> {
    return this.httpService.post<void>('/ebay/withdrawListing', data);
  }

  public async getEbayAuctionDetails(auctionId: string): Promise<EbayAuctionDetailsResponse> {
    return this.httpService.get<EbayAuctionDetailsResponse>(`/ebay/offerDetails/${auctionId}`);
  }

  public async updateEbayAuction(auctionId: string, data: CreateEbayAuctionRequest): Promise<void> {
    return this.httpService.post<void>(`/ebay/updateOffer/${auctionId}`, data);
  }
}

export {};
