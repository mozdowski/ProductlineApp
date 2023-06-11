import React from "react";
import "./css/CollapseOrderDetails.css"
import { OrdersRecord } from "../../../../interfaces/orders/OrdersPageInteface";

export const CollapseOrderDetails = ({ isOpen, orderRecords }: { isOpen: any, orderRecords: OrdersRecord[] }) => {
    return (
        <tr className="orderDetailsWrapper">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr >
    );
}
