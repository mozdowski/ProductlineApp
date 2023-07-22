import './css/ActiveAuctionsButton.css';

function ActiveAuctionsButton({
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
      className={showActiveAuctions ? 'activeAuctionsButton selected' : 'activeAuctionsButton'}
      onClick={() => onAuctionStateClick(true)}
    >
      <p>Aktywne</p>
    </div>
  );
}

export default ActiveAuctionsButton;
