import './css/ebayFormButton.css';

function EbayFormButton({
  setOpenEbayFormPopup,
}: {
  setOpenEbayFormPopup: (open: boolean) => void;
}) {
  return (
    <div className="ebayPortalButton" onClick={() => setOpenEbayFormPopup(true)}>
      <span className="iconPortalEbay ebayIcon" />
      <p>Ebay</p>
    </div>
  );
}

export default EbayFormButton;
