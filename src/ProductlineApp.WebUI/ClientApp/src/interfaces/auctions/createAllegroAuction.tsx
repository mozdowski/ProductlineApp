export interface CreateAllegroAuction {
  name: string;
  allegroProductId: string;
  description: string;
  impliedWarrantyId: string;
  returnPolicyId: string;
  price: number;
  location: Location;
  productId: string;
  parameters: Parameter[];
  duration: AllegroDurationPeriods;
  republish: boolean;
  imagesUrls: string[];
  shippingRateId: string;
  quantity: number;
  startingAt?: Date;
}

export interface Location {
  city: string;
  countryCode: string;
  postCode: string;
  province: string;
}

export interface Parameter {
  id?: string;
  name: string;
  values?: string[];
  valuesIds: string[];
}

export enum AllegroDurationPeriods {
  PT24H = 0,
  P2D,
  P3D,
  P4D,
  P5D,
  P7D,
  P10D,
  P14D,
  P21D,
  P30D,
  P60D,
}
