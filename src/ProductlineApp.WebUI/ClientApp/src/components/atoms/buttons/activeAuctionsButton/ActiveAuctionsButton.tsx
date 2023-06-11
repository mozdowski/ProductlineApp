import './css/ActiveAuctionsButton.css';

function ActiveAuctionsButton({ isSelectedTypeAuctions, handleClickTypeAuctionsButton, id }: { isSelectedTypeAuctions: any, handleClickTypeAuctionsButton: any, id: string }) {
    return (
        <div id={id} className={isSelectedTypeAuctions === "active" ? "activeAuctionsButton selected" : "activeAuctionsButton"} onClick={handleClickTypeAuctionsButton}>
            <p>Aktywne</p>
        </div>
    );
}

export default ActiveAuctionsButton