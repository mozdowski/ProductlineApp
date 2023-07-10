export interface AuctionForm {
  product: string;
  brand: string;
  name: string;
  condition: number;
  quantity: number;
  price: number;
  description: string;
  photos: FileList | null;

  allegroProductIdea: number;
}
