import { useContext } from 'react';
import { StatisticsContext } from '../../context/statisticsContext';

export const useStatisticsService = () => {
  const statisticsContext = useContext(StatisticsContext);

  if (!statisticsContext) {
    throw new Error('useStatisticsService must be used within an StatisticsProvider');
  }

  const { statisticsService } = statisticsContext;

  return { statisticsService };
};

export {};
