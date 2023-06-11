import React from "react";
import AddProductButton from "../components/atoms/buttons/addProductButtons/AddProductButton";
import ChangeDarkModeButtton from "../components/atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton";
import CountAuctionsChart from "../components/atoms/charts/CountAuctionsChart";
import MostPopularProductsChart from "../components/atoms/charts/MostPopularProductsChart";
import SoldTodayChart from "../components/atoms/charts/SoldTodayChart";
import UserAccountButton from "../components/atoms/buttons/userAccountButton/UserAccountButton";
import WeekSoldChart from "../components/atoms/charts/WeekSoldChart";

export default function Dashboard() {

    const actualDate = new Date();
    const date = actualDate.toLocaleString('default', {
        day: 'numeric',
        month: 'long',
        year: 'numeric'
    });

    return (
        <>
            <div className="heading">
                <div className="paageTitle">
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
                    <MostPopularProductsChart />
                    <CountAuctionsChart />
                    <WeekSoldChart />
                </div>
            </div>
        </>
    );
}