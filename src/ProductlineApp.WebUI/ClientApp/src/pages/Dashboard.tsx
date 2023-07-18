import React, { useEffect, useState } from 'react';
import AddProductButton from '../components/atoms/buttons/addProductButtons/AddProductButton';
import ChangeDarkModeButtton from '../components/atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton';
import CountAuctionsChart from '../components/atoms/charts/CountAuctionsChart';
import MostPopularProductsChart from '../components/atoms/charts/MostPopularProductsChart';
import SoldTodayChart from '../components/atoms/charts/SoldTodayChart';
import UserAccountButton from '../components/atoms/buttons/userAccountButton/UserAccountButton';
import WeekSoldChart from '../components/atoms/charts/WeekSoldChart';
import { AuctionsChartData } from '../interfaces/dashboard/auctionsChartData';
import { useStatisticsService } from '../hooks/statistics/useStatisticsService';
import { ProductStatistics } from '../interfaces/dashboard/mostPopularProductsChartData';

export default function Dashboard() {
  const actualDate = new Date();
  const date = actualDate.toLocaleString('default', {
    day: 'numeric',
    month: 'long',
    year: 'numeric',
  });

  const { statisticsService } = useStatisticsService();

  const [auctionsChartData, setAuctionsChartData] = useState<AuctionsChartData>({
    activeAuctionsCount: 0,
    allAuctionsCount: 60,
  });
  const [popularProductsChartData, setPopularProductsChartData] = useState<ProductStatistics[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const [auctionsCountData, mostPopularProductsData] = await Promise.all([
        statisticsService.getAuctionsChartData(),
        statisticsService.getMostPopularProductsChartData(),
      ]);

      setAuctionsChartData(auctionsCountData);
      setPopularProductsChartData(mostPopularProductsData.productsStatistics);
    };

    fetchData();
  }, []);

  return (
    <>
      <div className="heading">
        <div className="pageTitle">
          <h1>Dashboard</h1>
          <p>{date}</p>
        </div>
        <div className="pageUserActions">
          <ChangeDarkModeButtton />
          <AddProductButton />
          <UserAccountButton />
        </div>
      </div>
      <div className="content">
        <div className="charts">
          <SoldTodayChart />
          {popularProductsChartData.length > 0 && (
            <MostPopularProductsChart popularProductsChartData={popularProductsChartData} />
          )}
          <CountAuctionsChart auctionsChartData={auctionsChartData} />
          <WeekSoldChart />
        </div>
      </div>
    </>
  );
}
