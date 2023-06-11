import React, { useCallback, useState } from "react";
import CollapseIcon from "../../../../assets/icons/collapse_icon.png";
import CollapseOpenIcon from "../../assets/icons/collapseOpen_icon.png";
import './css/CollapseTableButton.css';


export const CollapseTableButton = ({ isOpen, toggle }: { isOpen: any, toggle: any }) => {
    return (
        <img className="collapseIcon" src={CollapseIcon} onClick={toggle}
            style={{
                transform: `rotate(${isOpen ? 90 : 0}deg)`,
                transition: "all 0.25s"
            }}
        />
    )
}