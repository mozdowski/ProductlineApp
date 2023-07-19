import './css/ebayFormButton.css';

function EbayFormButton({
  setOpenEbayFormPopup,
  isAssigned,
}: {
  setOpenEbayFormPopup: (open: boolean) => void;
  isAssigned: boolean;
}) {
  return (
    <div
      className={`ebayPortalButton ${isAssigned ? 'assigned' : ''}`}
      onClick={() => setOpenEbayFormPopup(true)}
    >
      <span className="iconPortalEbay ebayIcon" />
      <p>Ebay</p>
    </div>
  );
}

export default EbayFormButton;
