import jwtDecode, { JwtPayload } from 'jwt-decode';
import { useAuthContext } from './useAuthContext';
import { User } from '../../interfaces/auth/user';
import { toast } from 'react-toastify';

export const useAuth = () => {
  const authContext = useAuthContext();

  if (!authContext) {
    throw new Error('useAuth must be used within an AuthProvider');
  }

  const { user, register, login, logout, updateUserData } = authContext;

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
        toast.error('Brak autoryzacji');
        return false;
      }

      if (expirationDate && expirationDate < new Date()) {
        toast.info('Sesja wygasła. Zaloguj się ponownie');
        return false;
      }

      return true;
    } catch (error) {
      console.error('Błąd podczas weryfikacji tokena:', error);
      return false;
    }
  };

  const updateAvatar = (newAvatarUrl: string) => {
    if (!isAuthenticated()) return;

    const newUserData: User = {
      ...(user as User),
      avatar: newAvatarUrl,
    };

    updateUserData(newUserData);
  };

  return { user, register, login, logout, isAuthenticated, updateAvatar };
};

export {};
