import jwtDecode, { JwtPayload } from 'jwt-decode';
import { useAuthContext } from './useAuthContext';

export const useAuth = () => {
  const authContext = useAuthContext();

  if (!authContext) {
    throw new Error('useAuth must be used within an AuthProvider');
  }

  const { user, register, login, logout } = authContext;

  const isAuthenticated = () => {
    if (user?.authToken == undefined) {
      return false;
    }

    const isTokenValid = verifyToken(user.authToken);

    if (!isTokenValid) {
      logout();
      return false;
    }

    return isTokenValid;
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

  return { user, register, login, logout, isAuthenticated };
};

export {};
