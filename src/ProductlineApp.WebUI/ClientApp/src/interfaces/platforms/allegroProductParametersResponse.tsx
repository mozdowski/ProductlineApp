export interface AllegroProductParametersResponse {
  parameters: AllegroProductParameter[];
}

export interface AllegroProductParameter {
  id: string;
  name: string;
  type: string;
  required: boolean;
  unit: string;
  restrictions: ParameterRestrictions;
  dictionary?: DictionaryItem[];
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

interface DictionaryItem {
  id: string;
  value: string;
}
