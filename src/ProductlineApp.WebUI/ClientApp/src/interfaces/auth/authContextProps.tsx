import { User } from './user';

export interface AuthContextProps {
  user: User | null;
  register: (username: string, email: string, password: string) => Promise<any>;
  login: (email: string, password: string) => Promise<any>;
  logout: () => void;
  isAuthenticated: () => boolean;
}

export {};
