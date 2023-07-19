import './css/allegroFormButton.css';

function AllegroFormButton({
  setOpenAllegroFormPopup,
  isAssigned,
}: {
  setOpenAllegroFormPopup: any;
  isAssigned: boolean;
}) {
  return (
    <div
      className={`allegroPortalButton ${isAssigned ? 'assigned' : ''}`}
      onClick={() => setOpenAllegroFormPopup(true)}
    >
      <span className="iconPortalAllegro allegroIcon" />
      <p>Allegro</p>
    </div>
  );
}

export default AllegroFormButton;
