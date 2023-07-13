import { AllegroDurationPeriods, AllegroBasicParameter, Location } from "./createAllegroAuction";

export interface AllegroOfferProductDetailsResponse {
    name: string;
    allegroProductId: string;
    description: string;
    impliedWarrantyId: string;
    returnPolicyId: string;
    price: number;
    location: Location;
    productId: string;
    productParameters: AllegroBasicParameter[];
    listingParameters: AllegroBasicParameter[];
    duration: AllegroDurationPeriods;
    republish: boolean;
    imagesUrls: string[];
    shippingRateId: string;
    quantity: number;
    startingAt?: Date;
    categoryId: string;
}