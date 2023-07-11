import { useState } from 'react';
import { AuctionForm } from '../../../../../interfaces/auctions/auctionForm';
import AllegroFormButton from '../../../../atoms/buttons/AllegroFormButton/AllegroFormButton';
import EbayFormButton from '../../../../atoms/buttons/EbayFormButton/EbayFormButton';
import './css/auctionPortals.css';
import AllegroFormPopup from '../popups/allegro/AllegroFormPopup';
import { CreateAllegroAuction } from '../../../../../interfaces/auctions/createAllegroAuction';

function AuctionPortals({
  onAllegroFormSubmit,
}: {
  onAllegroFormSubmit: (form: CreateAllegroAuction) => void;
}) {
  const [openAllegroPopup, setOpenAllegroFormPopup] = useState(false);

  return (
    <>
      <div className="auctionPortals">
        <div className="sectionLabel">
          <div className="sectionNumber">
            <h1>4</h1>
          </div>
          <p>Portale aukcyjne</p>
        </div>
        <div className="addAuctionPortalsInputs">
          <AllegroFormButton setOpenAllegroFormPopup={setOpenAllegroFormPopup} />
          <AllegroFormPopup
            openAllegroPopup={openAllegroPopup}
            closeAllegroPopup={() => setOpenAllegroFormPopup(false)}
            onSubmit={onAllegroFormSubmit}
          />
          <EbayFormButton />
        </div>
      </div>
    </>
  );
}

export default AuctionPortals;
