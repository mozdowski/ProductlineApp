import React from "react";
import { Link, useMatch, useResolvedPath } from "react-router-dom";
import './css/ChangeDarkModeButtton.css';
import LightModeIcon from "../../../../assets/icons/lightMode_icon.png";
import DarkModeIcon from "../../../../assets/icons/darkMode_icon.png";


function ChangeDarkModeButtton() {
    return (
        <div className="changeDarkModeButtton">
            <input type="checkbox" id="darkmodeToggle" className="darkmodeToggle" />
            <label htmlFor="darkmodeToggle" className="darkModeLabel">
                <img id="lightMode" className="lightMode" src={LightModeIcon} />
                <img id="lightMode" className="darkMode" src={DarkModeIcon} />
            </label>
        </div>
    );
}

export default ChangeDarkModeButtton