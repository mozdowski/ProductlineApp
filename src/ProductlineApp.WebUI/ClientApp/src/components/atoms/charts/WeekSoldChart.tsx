import ReactEcharts from 'echarts-for-react';
import './css/WeekSoldChart.css';

interface DayOfWeek {
  id: number;
  name: string;
}

const getDaysOfWeek = (): string[] => {
  const daysOfWeek: DayOfWeek[] = [];
  const days = ['Niedziela', 'Poniedziałek', 'Wtorek', 'Środa', 'Czwartek', 'Piątek', 'Sobota'];

  const today = new Date();
  const currentDayOfWeek = today.getDay();

  for (let i = currentDayOfWeek; i >= 0; i--) {
    const dayName = i === currentDayOfWeek ? 'Dzisiaj' : days[i];
    daysOfWeek.push({ id: i, name: dayName });
  }

  if (currentDayOfWeek >= 0) {
    for (let i = days.length - 1; i >= currentDayOfWeek + 1; i--) {
      daysOfWeek.push({ id: i, name: days[i] });
    }
  }

  return daysOfWeek.map((x) => x.name).reverse();
};

function WeekSoldChart({ weeklySellsChartData }: { weeklySellsChartData: number[] }) {
  const option = {
    tooltip: {
      trigger: 'axis',
      axisPointer: {
        type: 'shadow',
      },
    },
    grid: {
      left: '3%',
      right: '3%',
      bottom: '5%',
      containLabel: true,
    },
    xAxis: [
      {
        type: 'category',
        data: getDaysOfWeek(),
        axisTick: {
          alignWithLabel: true,
        },
        color: '#434343',
      },
    ],
    yAxis: [
      {
        type: 'value',
      },
    ],
    series: [
      {
        itemStyle: {
          borderRadius: [8, 8, 0, 0],
        },
        type: 'bar',
        barWidth: '40%',
        color: '#5F47F1',
        data: weeklySellsChartData,
      },
    ],
  };

  return (
    <div className="chart4">
      <h1>Sprzedaż Tygodnia</h1>
      <ReactEcharts option={option} style={{ height: '340px' }} />
    </div>
  );
}

export default WeekSoldChart;
