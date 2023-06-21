import { Address } from '../common/address';

export interface BillingAddress {
  firstName: string;
  lastName?: string | null;
  username: string;
  email: string;
  phoneNumber: string;
  address: Address;
}
