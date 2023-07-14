import './css/ActiveAuctionsButton.css';

function ActiveAuctionsButton({
  showActiveAuctions,
  handleClickTypeAuctionsButton,
  id,
}: {
  showActiveAuctions: boolean;
  handleClickTypeAuctionsButton: any;
  id: string;
}) {
  return (
    <div
      id={id}
      className={showActiveAuctions ? 'activeAuctionsButton selected' : 'activeAuctionsButton'}
      onClick={handleClickTypeAuctionsButton}
    >
      <p>Aktywne</p>
    </div>
  );
}

export default ActiveAuctionsButton;
