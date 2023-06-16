import { ProductCondition } from '../enums/productCondition';

export const mapProductConditionToString = (condition: ProductCondition): string => {
  switch (condition) {
    case ProductCondition.NEW:
      return 'Nowy';
    case ProductCondition.USED:
      return 'Uzywany';
    default:
      return '';
  }
};
