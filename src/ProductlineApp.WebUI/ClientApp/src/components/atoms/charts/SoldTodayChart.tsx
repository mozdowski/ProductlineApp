import ReactEcharts from 'echarts-for-react';
import './css/SoldTodayChart.css';
import { ProductStatistics } from '../../../interfaces/dashboard/mostPopularProductsChartData';

function SoldTodayChart({
  soldTodayProductsChartData,
}: {
  soldTodayProductsChartData: ProductStatistics[];
}) {
  const data = soldTodayProductsChartData.map((x) => ({
    name: x.name,
    value: x.soldCount,
  }));

  const option = {
    tooltip: {
      trigger: 'item',
    },
    legend: {
      bottom: '1%',
      left: 'center',
    },
    series: [
      {
        color: ['pink', 'purple', 'ff0000', 'red', 'blue'],
        type: 'pie',
        radius: ['35%', '65%'],
        avoidLabelOverlap: false,
        itemStyle: {
          borderRadius: 10,
          borderColor: '#fff',
          borderWidth: 2,
        },
        label: {
          show: false,
          position: 'center',
        },
        emphasis: {
          label: {
            show: true,
            fontSize: 16,
            fontWeight: 'bold',
            fontFamiy: 'Poppins, sans-serif',
          },
        },
        labelLine: {
          show: false,
        },
        data: data,
      },
    ],
  };

  return (
    <div className="chart1">
      <h1>Sprzedane Dzisiaj</h1>
      <ReactEcharts option={option} style={{ height: '340px' }} />
    </div>
  );
}

export default SoldTodayChart;

/*
const option = {
        tooltip: {
            trigger: 'item'
        },
        legend: {
            marginBottom: "20px"
        },
        series: [
            {
                name: 'Access From',
                type: 'pie',
                radius: '60%',
                label: {
                    show: false
                },
                data: [
                    { value: 1048, name: 'Search Engine' },
                    { value: 735, name: 'Direct' },
                    { value: 580, name: 'Email' },
                    { value: 484, name: 'Union Ads' },
                    { value: 300, name: 'Video Ads' }
                ],
                emphasis: {
                    itemStyle: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                }
            }
        ]
    };
*/
