import './css/allegroFormButton.css';

function AllegroFormButton({ setOpenAllegroFormPopup }: { setOpenAllegroFormPopup: any }) {
  return (
    <div className="allegroPortalButton" onClick={() => setOpenAllegroFormPopup(true)}>
      <span className="iconPortalAllegro allegroIcon" />
      <p>Allegro</p>
    </div>
  );
}

export default AllegroFormButton;
