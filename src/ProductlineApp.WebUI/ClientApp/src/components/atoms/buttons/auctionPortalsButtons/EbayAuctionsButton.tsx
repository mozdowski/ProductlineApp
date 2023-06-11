import React, { useState } from "react";
import EbayIcon from "../../../../assets/icons/ebay_icon1.svg";
import './css/ebayAuctionsButton.css';

function EbayAuctionsButton({ isSelectedAuctionPortal, handleClickTypeAuctionPortalButton, id }: { isSelectedAuctionPortal: any, handleClickTypeAuctionPortalButton: any, id: string }) {

    return (
        <div id={id} className={isSelectedAuctionPortal === "ebay" ? "ebayButton selected" : "ebayButton"} onClick={handleClickTypeAuctionPortalButton}>
            <img className="ebayIcon" src={EbayIcon} />
        </div>
    );
}

export default EbayAuctionsButton