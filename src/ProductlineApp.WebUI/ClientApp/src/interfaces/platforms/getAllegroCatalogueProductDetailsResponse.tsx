interface Category {
  id: string;
  similar: Category[];
}

interface RangeValue {
  from: string;
  to: string;
}

interface Options {
  identifiesProduct: boolean;
  isGTIN: boolean;
}

export interface Parameter {
  id: string;
  name: string;
  rangeValue: RangeValue;
  values: string[];
  valuesIds: string[];
  valuesLabels: string[];
  unit: string;
  options: Options;
}

export interface OfferRequirements {
  id: string;
  parameters: Parameter[];
}

interface CompatibilityItem {
  text: string;
}

interface CompatibilityList {
  id: string;
  type: string;
  items: CompatibilityItem[];
}

interface TecdocSpecificationItem {
  name: string;
  values: string[];
}

interface DescriptionItem {
  type: string;
}

interface DescriptionSection {
  items: DescriptionItem[];
}

interface TecdocSpecification {
  id: string;
  items: TecdocSpecificationItem[];
}

interface Description {
  sections: DescriptionSection[];
}

export interface GetAllegroCatalogueProductDetailsResponse {
  id: string;
  name: string;
  category: Category;
  images: any[];
  parameters: Parameter[];
  offerRequirements: OfferRequirements;
  compatibilityList: CompatibilityList;
  tecdocSpecification: TecdocSpecification;
  description: Description;
  isDraft: boolean;
}
