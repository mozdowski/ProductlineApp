import React from "react"
import "./css/AuctionsHederActions.css"
import Searchbar from "../../../atoms/inputs/searchbarInput/Searchbar"
import ActiveAuctionButton from "../../../atoms/buttons/activeAuctionsButton/ActiveAuctionsButton"
import EndAuctionButton from "../../../atoms/buttons/endAuctionsButton/EndAuctionButton"
import AddAuctionButton from "../../../atoms/buttons/addAuctionButton/AddAuctionButton"

export const AuctionsHederActions = ({ isSelectedTypeAuctions, handleClickTypeAuctionsButton }: { isSelectedTypeAuctions: any, handleClickTypeAuctionsButton: any }) => {

    return (
        <>
            <div className="AuctionsTableButtons">
                <div className="changeTypeAuctionsButtons">
                    <ActiveAuctionButton id={"active"} isSelectedTypeAuctions={isSelectedTypeAuctions} handleClickTypeAuctionsButton={handleClickTypeAuctionsButton} />
                    <EndAuctionButton id={"ended"} isSelectedTypeAuctions={isSelectedTypeAuctions} handleClickTypeAuctionButton={handleClickTypeAuctionsButton} />
                </div>
                <div className="AuctionsTableActionButtons">
                    <Searchbar />
                    <AddAuctionButton />
                </div>
            </div>
        </>
    )
}
