import { ReactNode } from 'react';
import { useAuth } from '../hooks/auth/useAuth';
import { UserService } from '../services/user/user.service';
import { UserContext } from '../context/userContext';

interface UserProviderProps {
  children: ReactNode;
}

export const UserProvider: React.FC<UserProviderProps> = ({ children }) => {
  const { user } = useAuth();

  const userService = new UserService(user?.authToken);

  return <UserContext.Provider value={{ userService }}>{children}</UserContext.Provider>;
};
