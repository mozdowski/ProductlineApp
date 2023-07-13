import { AuctionsService } from '../../services/auctions/auctions.service';
import { ProductAuctionData } from '../products/getProductsSKU';

export interface AuctionsContextProps {
  auctionsService: AuctionsService;
}
