import React, { ReactNode, useEffect, useState } from 'react';
import { AuthContext } from '../context/authContext';
import { User } from '../interfaces/auth/user';
import { AuthContextProps } from '../interfaces/auth/authContextProps';
import { AuthService } from '../services/auth/auth.service';
import { LoginRequest } from '../interfaces/auth/loginRequest';
import { RegisterRequest } from '../interfaces/auth/registerRequest';
import jwtDecode, { JwtPayload } from 'jwt-decode';

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

  const register = (data: RegisterRequest): Promise<void> => {
    const formData = new FormData();

    Object.entries(data).forEach(([key, value]) => {
      formData.append(key, value);
    });

    return authService.register(formData).then((res) => {
      const userResponse: User = {
        id: res.id,
        name: res.username,
        email: res.email,
        authToken: res.token,
        avatar: res.avatar,
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
        avatar: res.avatar,
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
    if (user?.authToken == undefined) {
      return false;
    }

    const isTokenValid = verifyToken(user.authToken);

    if (!isTokenValid) {
      logout();
    }

    return isTokenValid;
  };

  const authContextValue: AuthContextProps = {
    user,
    register,
    login,
    logout,
    isAuthenticated,
  };

  const verifyToken = (token: string): boolean => {
    try {
      const decodedToken: JwtPayload = jwtDecode(token);
      const { sub, exp } = decodedToken;

      const expirationDate = exp ? new Date(exp * 1000) : null;

      if (sub != user?.id) {
        console.error('Unauthorized');
        return false;
      }

      if (expirationDate && expirationDate < new Date()) {
        console.error('Token wygasl');
        return false;
      }

      return true;
    } catch (error) {
      console.error('Błąd podczas weryfikacji tokena:', error);
      return false;
    }
  };

  return <AuthContext.Provider value={authContextValue}>{children}</AuthContext.Provider>;
};

export {};
