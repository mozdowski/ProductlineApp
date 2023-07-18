import { PlatformEnum } from "../../enums/platform.enum";
import { ProductCondition } from "../../enums/productCondition";

export interface ProductAuctionData {
  id: string;
  sku: string;
  imageUrls: string[];
  brand: string;
  name: string;
  condition: number;
  quantity: number;
  price: number;
  description: string;
}

export interface ProductData {
  id: string;
  sku: string;
  name: string;
  imageUrls: string[];
  imageUrl: string;
  brand: string;
  condition: ProductCondition;
  quantity: number;
  price: number;
  description: string;
  category: string;
  platforms: PlatformEnum[];
}
