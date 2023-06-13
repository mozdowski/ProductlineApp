import React from 'react';
import ReactEcharts from 'echarts-for-react';
import './css/MostPopularProductsChart.css';

function MostPopularProductsChart() {
  const option = {
    tooltip: {
      trigger: 'item',
    },
    visualMap: {
      show: false,
      min: 80,
      max: 600,
      inRange: {
        colorLightness: [0, 1],
      },
    },
    series: [
      {
        type: 'pie',
        radius: '70%',
        center: ['50%', '50%'],
        data: [
          { value: 335, name: 'Direct' },
          { value: 310, name: 'Email' },
          { value: 274, name: 'Union Ads' },
          { value: 235, name: 'Video Ads' },
          { value: 400, name: 'Search Engine' },
        ].sort(function (a, b) {
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
