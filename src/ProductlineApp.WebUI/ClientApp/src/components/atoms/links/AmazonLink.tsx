import React from "react";
import AmazonIcon from "../../../assets/icons/amazon_icon1.svg"
import './css/AmazonLink.css';

function AmazonLink() {
    return (
        <a href="https://www.amazon.pl" target="_blank" rel="noopener noreferrer" className="amazonLink">
            <img src={AmazonIcon} className="amazonIcon"></img>
        </a>
    );
}

export default AmazonLink
