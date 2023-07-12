import { useContext } from 'react';
import { UserContext } from '../../context/userContext';

export const useUserService = () => {
  const userContext = useContext(UserContext);

  if (!userContext) {
    throw new Error('useAuth must be used within an AuthProvider');
  }

  const { userService } = userContext;

  return { userService };
};

export {};
