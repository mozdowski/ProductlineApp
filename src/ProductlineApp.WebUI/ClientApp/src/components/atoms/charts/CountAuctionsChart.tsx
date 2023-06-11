import React from "react";
import ReactEcharts from "echarts-for-react";
import './css/CountAuctionsChart.css';

function CountAuctionsChart() {
    const option = {
        series: [
            {
                type: 'gauge',
                center: ['50%', '60%'],
                startAngle: 210,
                endAngle: -30,
                min: 0,
                max: 60,
                splitNumber: 12,
                itemStyle: {
                    color: '#5F47F1'
                },
                progress: {
                    show: true,
                    width: 25,
                    itemStyle: {
                        berderRadius: 8
                    },
                },
                pointer: {
                    show: false
                },
                axisLine: {
                    lineStyle: {
                        width: 25,
                    }
                },
                axisTick: {
                    show: false,
                    distance: -45,
                    splitNumber: 5,
                    lineStyle: {
                        width: 2,
                        color: '#999'
                    }
                },
                splitLine: {
                    show: false,
                    distance: -52,
                    length: 14,
                    lineStyle: {
                        width: 3,
                        color: '#999'
                    }
                },
                axisLabel: {
                    distance: -20,
                    show: false,
                    fontSize: 20
                },
                anchor: {
                    show: false
                },
                title: {
                    show: false
                },
                detail: {
                    valueAnimation: true,
                    lineHeight: 60,
                    borderRadius: 8,
                    offsetCenter: [0, '-15%'],
                    fontSize: 60,
                    fontWeight: 'bolder',
                    formatter: '{value}',
                    color: 'inherit'
                },
                data: [
                    {
                        value: 20
                    }
                ]
            },
            {
                type: 'gauge',
                center: ['50%', '60%'],
                startAngle: 200,
                endAngle: -20,
                min: 0,
                max: 60,
                itemStyle: {
                    color: '',
                    borderRadius: 8
                },
                progress: {
                    show: false,
                    width: 8
                },
                pointer: {
                    show: false
                },
                axisLine: {
                    show: false
                },
                axisTick: {
                    show: false
                },
                splitLine: {
                    show: false
                },
                axisLabel: {
                    show: false
                },
                detail: {
                    show: false
                },
                data: [
                    {
                        value: 20
                    }
                ]
            }
        ]
    };

    return (
        <div className="chart3">
            <h1>Wystawione Aukje</h1>
            <ReactEcharts option={option} style={{ height: "340px" }} />
        </div>
    );
}

export default CountAuctionsChart
