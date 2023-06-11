import './css/AuctionsTemplate.css';
import { AuctionsRecord } from "../../interfaces/auctions/AuctionsPageInteface";
import AuctionsPageHeader from '../organisms/pageHeaders/AuctionsPageHeader';
import AuctionsTable from '../organisms/tables/AuctionsTable';
import AmazonAuctionsButton from "../atoms/buttons/auctionPortalsButtons/AmazonAuctionsButton";
import EbayAuctionsButton from "../atoms/buttons/auctionPortalsButtons/EbayAuctionsButton";
import OlxAuctionsButton from "../atoms/buttons/auctionPortalsButtons/OlxAuctionsButton";

export default function AuctionsTemplate({ auctionRecords, isSelectedAuctionPortal, handleClickTypeAuctionPortalButton, handleClickTypeAuctionsButton, isSelectedTypeAuctions }: { auctionRecords: AuctionsRecord[], isSelectedAuctionPortal: any, handleClickTypeAuctionPortalButton: any, handleClickTypeAuctionsButton: any, isSelectedTypeAuctions: any }) {
    return (
        <>
            <AuctionsPageHeader />
            <div className="auctionPortalsButtons">
                <EbayAuctionsButton id="ebay" isSelectedAuctionPortal={isSelectedAuctionPortal} handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton} />
                <AmazonAuctionsButton id="amazon" isSelectedAuctionPortal={isSelectedAuctionPortal} handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton} />
                <OlxAuctionsButton id="olx" isSelectedAuctionPortal={isSelectedAuctionPortal} handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton} />
            </div>
            <div className="content">
                <div className="tableAuctions">
                    <AuctionsTable auctionRecords={auctionRecords} isSelectedTypeAuctions={isSelectedTypeAuctions} handleClickTypeAuctionsButton={handleClickTypeAuctionsButton} />
                </div>
            </div>
        </>
    );
}