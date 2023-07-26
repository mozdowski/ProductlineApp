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

const getUserFromLocalStorage = (): User | null => {
  const userFromLocalStorage = localStorage.getItem('user');
  return userFromLocalStorage ? JSON.parse(userFromLocalStorage) : null;
};

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [user, setUser] = useState<User | null>(getUserFromLocalStorage());
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

  const updateUserData = (newUserData: User) => {
    setUser(newUserData);
    localStorage.setItem('user', JSON.stringify(newUserData));
  };

  const authContextValue: AuthContextProps = {
    user,
    register,
    login,
    logout,
    updateUserData,
  };

  return <AuthContext.Provider value={authContextValue}>{children}</AuthContext.Provider>;
};

export {};
