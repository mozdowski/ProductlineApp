import { Address } from '../common/address';

export interface ShippingAddress {
  firstName: string;
  lastName?: string | null;
  companyName?: string | null;
  phoneNumber: string;
  address: Address;
}
