import { User } from "./user";

export interface AuthContextProps {
    user: User | null;
    register: (username: string, email: string, password: string) => void;
    login: (email: string, password: string) => void;
    logout: () => void;
    isAuthenticated: () => boolean;
}

export { };