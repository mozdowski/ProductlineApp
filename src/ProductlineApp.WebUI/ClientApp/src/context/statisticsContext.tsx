import { createContext } from 'react';
import { StatisticsService } from '../services/statistics/statistics.service';

export interface StatisticsContextProps {
  statisticsService: StatisticsService;
}

export const StatisticsContext = createContext<StatisticsContextProps | undefined>(undefined);
