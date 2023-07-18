import { ReactNode } from 'react';
import { useAuth } from '../hooks/auth/useAuth';
import { StatisticsService } from '../services/statistics/statistics.service';
import { StatisticsContext } from '../context/statisticsContext';

interface StatisticsProviderProps {
  children: ReactNode;
}

export const StatisticsProvider: React.FC<StatisticsProviderProps> = ({ children }) => {
  const { user } = useAuth();

  const statisticsService = new StatisticsService(user?.authToken);

  return (
    <StatisticsContext.Provider value={{ statisticsService }}>
      {children}
    </StatisticsContext.Provider>
  );
};
