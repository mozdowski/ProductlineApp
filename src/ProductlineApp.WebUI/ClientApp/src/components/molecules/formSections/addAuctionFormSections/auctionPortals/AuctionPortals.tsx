import { useState } from 'react';
import AllegroFormButton from '../../../../atoms/buttons/AllegroFormButton/AllegroFormButton';
import EbayFormButton from '../../../../atoms/buttons/EbayFormButton/EbayFormButton';
import './css/auctionPortals.css';
import AllegroFormPopup from '../popups/allegro/AllegroFormPopup';
import { CreateAllegroAuction } from '../../../../../interfaces/auctions/createAllegroAuction';
import { usePlatforms } from '../../../../../hooks/platforms/usePlatforms';

function AuctionPortals({
  onAllegroFormSubmit,
  platformConnections,
}: {
  onAllegroFormSubmit: (form: CreateAllegroAuction) => void;
  platformConnections: string[];
}) {
  const [openAllegroPopup, setOpenAllegroFormPopup] = useState(false);
  const { allegroPlatform, ebayPlatform } = usePlatforms();

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
          {allegroPlatform && platformConnections.includes(allegroPlatform.platformId) && (
            <>
              <AllegroFormButton setOpenAllegroFormPopup={setOpenAllegroFormPopup} />
              <AllegroFormPopup
                openAllegroPopup={openAllegroPopup}
                closeAllegroPopup={() => setOpenAllegroFormPopup(false)}
                onSubmit={onAllegroFormSubmit}
              />
            </>
          )}
          {ebayPlatform && platformConnections.includes(ebayPlatform.platformId) && (
            <EbayFormButton />
          )}
        </div>
      </div>
    </>
  );
}

export default AuctionPortals;
