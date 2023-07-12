import jwtDecode, { JwtPayload } from 'jwt-decode';
import { useAuthContext } from './useAuthContext';
import { User } from '../../interfaces/auth/user';

export const useAuth = () => {
  const authContext = useAuthContext();

  if (!authContext) {
    throw new Error('useAuth must be used within an AuthProvider');
  }

  const { user, register, login, logout } = authContext;

  const isAuthenticated = () => {
    const userFromLocalStorage = localStorage.getItem('user');
    let parsedUser: User | null = null;
    if (userFromLocalStorage) {
      parsedUser = JSON.parse(userFromLocalStorage);
    }

    if (!parsedUser || parsedUser.authToken == undefined) return false;

    const isTokenValid = verifyToken(parsedUser.authToken, parsedUser);

    if (!isTokenValid) {
      logout();
      return false;
    }

    return isTokenValid;
  };

  const verifyToken = (token: string, user: User): boolean => {
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

  return { user, register, login, logout, isAuthenticated };
};

export {};
