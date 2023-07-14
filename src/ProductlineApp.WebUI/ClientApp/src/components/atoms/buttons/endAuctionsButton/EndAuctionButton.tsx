import './css/EndAuctionButton.css';

function EndAuctionButton({
  showActiveAuctions,
  handleClickTypeAuctionButton,
  id,
}: {
  showActiveAuctions: boolean;
  handleClickTypeAuctionButton: any;
  id: string;
}) {
  return (
    <div
      id={id}
      className={!showActiveAuctions ? 'endAuctionButton selected' : 'endAuctionButton'}
      onClick={handleClickTypeAuctionButton}
    >
      <p>Zakończone</p>
    </div>
  );
}

export default EndAuctionButton;
