import './css/EndAuctionButton.css';

function EndAuctionButton({ isSelectedTypeAuctions, handleClickTypeAuctionButton, id }: { isSelectedTypeAuctions: any, handleClickTypeAuctionButton: any, id: string }) {
    return (
        <div id={id} className={isSelectedTypeAuctions === "ended" ? "endAuctionButton selected" : "endAuctionButton"} onClick={handleClickTypeAuctionButton}>
            <p>Zakończone</p>
        </div>
    );
}

export default EndAuctionButton