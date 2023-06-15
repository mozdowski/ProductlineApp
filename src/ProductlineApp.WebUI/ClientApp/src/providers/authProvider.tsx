import React, { ReactNode, useEffect, useState } from 'react';
import { AuthContext } from '../context/authContext';
import { User } from '../interfaces/auth/user';
import { AuthContextProps } from '../interfaces/auth/authContextProps';
import { AuthService } from '../services/auth/auth.service';
import { LoginRequest } from '../interfaces/auth/loginRequest';
import { RegisterRequest } from '../interfaces/auth/registerRequest';

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [user, setUser] = useState<User | null>(null);
  const authService = new AuthService();

  useEffect(() => {
    const userFromLocalStorage = localStorage.getItem('user');
    if (userFromLocalStorage) {
      setUser(JSON.parse(userFromLocalStorage));
    }
  }, []);

  const register = (username: string, email: string, password: string): Promise<void> => {
    const requestBody: RegisterRequest = {
      username: username,
      email: email,
      password: password,
    };

    return authService.register(requestBody).then((res) => {
      const userResponse: User = {
        id: res.id,
        name: res.username,
        email: res.email,
        authToken: res.token,
      };

      setUser(userResponse);
      localStorage.setItem('user', JSON.stringify(userResponse));
    });
  };

  const login = (email: string, password: string): Promise<void> => {
    const requestBody: LoginRequest = {
      email: email,
      password: password,
    };

    return authService.login(requestBody).then((res) => {
      const userResponse: User = {
        id: res.id,
        name: res.username,
        email: res.email,
        authToken: res.token,
      };

      setUser(userResponse);
      localStorage.setItem('user', JSON.stringify(userResponse));
    });
  };

  const logout = () => {
    setUser(null);
    localStorage.removeItem('user');
  };

  const isAuthenticated = () => {
    return user?.authToken != null;
  };

  const authContextValue: AuthContextProps = {
    user,
    register,
    login,
    logout,
    isAuthenticated,
  };

  return <AuthContext.Provider value={authContextValue}>{children}</AuthContext.Provider>;
};

export {};
