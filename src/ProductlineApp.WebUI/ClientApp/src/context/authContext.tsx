import { createContext } from "react";
import { AuthContextProps } from "../interfaces/auth/authContextProps";

export const AuthContext = createContext<AuthContextProps | undefined>(undefined);

export { };