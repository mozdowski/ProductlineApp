import { OrderStatus } from '../enums/orderStatus.enum';
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

export const mapOrderStatusToString = (status: OrderStatus): string => {
  switch (status) {
    case OrderStatus.PENDING:
      return 'W trakcie przygotowania';
    case OrderStatus.SHIPPED:
      return 'Wyslany';
    case OrderStatus.DELIVERED:
      return 'Dostarczony';
    case OrderStatus.CANCELLED:
      return 'Anulowany';
    case OrderStatus.RETURNED:
      return 'Zwrocony';
    case OrderStatus.COMPLETED:
      return 'Zakończone';
    default:
      return '';
  }
};
