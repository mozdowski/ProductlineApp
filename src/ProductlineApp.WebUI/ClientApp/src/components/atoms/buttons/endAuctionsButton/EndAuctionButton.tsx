import './css/EndAuctionButton.css';

function EndAuctionButton({
  showActiveAuctions,
  onAuctionStateClick,
  id,
}: {
  showActiveAuctions: boolean;
  onAuctionStateClick: (showActive: boolean) => void;
  id: string;
}) {
  return (
    <div
      id={id}
      className={!showActiveAuctions ? 'endAuctionButton selected' : 'endAuctionButton'}
      onClick={() => onAuctionStateClick(false)}
    >
      <p>Zakończone</p>
    </div>
  );
}

export default EndAuctionButton;
