import { ProductAuctionData } from '../products/getProductsSKU';

export interface AddAuctionContextProps {
  selectedProduct: ProductAuctionData;
  setSelectedProduct: (selectedProduct: ProductAuctionData) => void;
}
