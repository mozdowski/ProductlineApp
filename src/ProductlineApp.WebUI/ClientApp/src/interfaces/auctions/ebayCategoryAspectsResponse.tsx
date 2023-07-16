export interface EbayCategoryAspectsResponse {
  platformAspects: EbayCategoryAspect[];
}

export interface EbayCategoryAspect {
  name: string;
  dataType: string;
  isRequired: boolean;
  values: string[];
}
