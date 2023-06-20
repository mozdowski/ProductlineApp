import { RegisterRequest } from './registerRequest';
import { User } from './user';

export interface AuthContextProps {
  user: User | null;
  register: (data: RegisterRequest) => Promise<any>;
  login: (email: string, password: string) => Promise<any>;
  logout: () => void;
}

export {};
