export interface GetAllegroCalalogueResponse {
  products: AllegroCatalogueProduct[];
}

interface Description {
  sections: Section[];
}

interface Section {
  items: Item[];
}

interface Item {
  type: string;
}

interface Category {
  id: string;
  similar: SimilarCategory[];
}

interface SimilarCategory {
  id: string;
}

interface Image {
  url?: string;
}

interface RangeValue {
  from: string;
  to: string;
}

interface Options {
  identifiesProduct: boolean;
  isGTIN: boolean;
}

interface Parameter {
  id: string;
  name: string;
  rangeValue: RangeValue;
  values: string[];
  valuesIds: string[];
  valuesLabels: string[];
  unit: string;
  options: Options;
}

export interface AllegroCatalogueProduct {
  id: string;
  name: string;
  description: Description;
  category: Category;
  images: Image[];
  parameters: Parameter[];
  isDraft: boolean;
}

interface Subcategory {
  id: string;
  name: string;
  count: number;
}

interface Path {
  id: string;
  name: string;
}

interface FilterValue {
  name: string;
  value: string;
  idSuffix: string;
  count: number;
  selected: boolean;
}

interface Filter {
  id: string;
  type: string;
  name: string;
  values: FilterValue[];
  minValue: number;
  maxValue: number;
  unit: string;
}
