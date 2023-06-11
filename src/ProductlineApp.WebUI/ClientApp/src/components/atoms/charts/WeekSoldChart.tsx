import React, { PureComponent } from "react";
import ReactEcharts, { EChartsReactProps } from "echarts-for-react";
import './css/WeekSoldChart.css';
import echarts from "echarts/types/dist/echarts";
import EChartsReactCore from "echarts-for-react/lib/core";

function WeekSoldChart() {

    const option = {
        tooltip: {
            trigger: 'axis',
            axisPointer: {
                type: 'shadow'
            }
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
                data: ['Poniedziałek', 'Wtorek', 'Środa', 'Czwartek', 'Piątek', 'Sobota', 'Niedziela'],
                axisTick: {
                    alignWithLabel: true
                },
                color: '#434343'
            }
        ],
        yAxis: [
            {
                type: 'value'
            }
        ],
        series: [
            {
                itemStyle: {
                    borderRadius: [8, 8, 0, 0]
                },
                type: 'bar',
                barWidth: '40%',
                color: '#5F47F1',
                data: [555, 52, 200, 334, 390, 330, 220]
            }
        ]
    };

    return (
        <div className="chart4">
            <h1>Sprzedaz Tygodnia</h1>

            <ReactEcharts option={option} style={{ height: "340px" }} />
        </div>
    );
}

export default WeekSoldChart