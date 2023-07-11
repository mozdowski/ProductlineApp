export interface AllegroProductParametersResponse {
  parameters: AllegroProductParameter[];
}

export interface AllegroProductParameter {
  id: string;
  name: string;
  type: string;
  required: boolean;
  requiredForProduct: boolean;
  unit: string;
  restrictions: ParameterRestrictions;
  dictionary?: DictionaryItem[];
  options?: CategoryParameterOptions;
}

interface CategoryParameterOptions {
  describesProduct?: boolean;
}

export interface ParameterRestrictions {
  min?: number;
  max?: number;
  range?: boolean;
  precision?: number;
  minLength?: number;
  maxLength?: number;
  allowedNumberOfValues?: number;
  multipleChoices?: boolean;
}

export interface DictionaryItem {
  id: string;
  value: string;
}
