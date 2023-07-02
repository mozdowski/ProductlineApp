import { useState } from 'react';
import { AuctionForm } from '../../../../../interfaces/auctions/auctionForm';
import AllegroFormButton from '../../../../atoms/buttons/AllegroFormButton/AllegroFormButton';
import EbayFormButton from '../../../../atoms/buttons/EbayFormButton/EbayFormButton';
import './css/auctionPortals.css';
import AllegroFormPopup from '../popups/AllegroFormPopup';

function AuctionPortals({
  auctionForm,
  //onChange,
  errors,
}: {
  auctionForm: AuctionForm;
  //onChange: (name: string, value: string | number) => void;
  errors: Partial<AuctionForm>;
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
            errors={errors}
            closeAllegroPopup={() => setOpenAllegroFormPopup(false)}
          />
          <EbayFormButton />
        </div>
      </div>
    </>
  );
}

export default AuctionPortals;
