import ReactEcharts from 'echarts-for-react';
import './css/MostPopularProductsChart.css';
import { ProductStatistics } from '../../../interfaces/dashboard/mostPopularProductsChartData';

function MostPopularProductsChart({
  popularProductsChartData,
}: {
  popularProductsChartData: ProductStatistics[];
}) {
  const colors = ['#5F47F1', '#FF825C', '#FFC24C', '#E816C2', '#F9F871'];

  const data = popularProductsChartData.map((x, index) => ({
    name: x.name,
    value: x.soldCount,
    itemStyle: {
      color: colors[index],
    },
  }));

  const option = {
    tooltip: {
      trigger: 'item',
    },
    visualMap: {
      show: false,
      min: 1,
      max: 1000,
      inRange: {
        colorLightness: [0, 1],
      },
    },
    series: [
      {
        type: 'pie',
        radius: '70%',
        center: ['50%', '50%'],
        data: data.sort(function (a, b) {
          return a.value - b.value;
        }),
        roseType: 'radius',
        label: {
          color: '#434343',
        },
        labelLine: {
          lineStyle: {
            color: '#5F47F1',
          },
          smooth: 0.2,
          length: 10,
          length2: 20,
        },
        itemStyle: {
          color: '#5F47F1',
          shadowBlur: 200,
          shadowColor: 'rgba(0, 0, 0, 0)',
          borderRadius: 8,
        },
        animationType: 'scale',
        animationEasing: 'elasticOut',
        animationDelay: function () {
          return Math.random() * 200;
        },
      },
    ],
  };

  return (
    <div className="chart2">
      <h1>Najpopularniejsze Produkty</h1>
      <ReactEcharts option={option} style={{ height: '340px' }} />
    </div>
  );
}

export default MostPopularProductsChart;
