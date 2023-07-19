import { useState } from 'react';
import AllegroFormButton from '../../../../atoms/buttons/AllegroFormButton/AllegroFormButton';
import EbayFormButton from '../../../../atoms/buttons/EbayFormButton/EbayFormButton';
import './css/auctionPortals.css';
import AllegroFormPopup from '../popups/allegro/AllegroFormPopup';
import { CreateAllegroAuction } from '../../../../../interfaces/auctions/createAllegroAuction';
import { usePlatforms } from '../../../../../hooks/platforms/usePlatforms';
import EbayFormPopup from '../popups/ebay/ebayFormPopup';
import { CreateEbayAuctionRequest } from '../../../../../interfaces/auctions/createEbayAuctionRequest';
import BasicTooltip from '../../../../atoms/common/tooltip/basicTooltip';
import { PlatformEnum } from '../../../../../enums/platform.enum';

function AuctionPortals({
  onAllegroFormSubmit,
  onEbayFormSubmit,
  platformConnections,
  assignedPortals,
}: {
  onAllegroFormSubmit: (form: CreateAllegroAuction) => void;
  onEbayFormSubmit: (form: CreateEbayAuctionRequest) => void;
  platformConnections: string[];
  assignedPortals: PlatformEnum[];
}) {
  const [openAllegroPopup, setOpenAllegroFormPopup] = useState(false);
  const [openEbayPopup, setOpenEbayFormPopup] = useState(false);
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
            <BasicTooltip title="Stwórz formularz wystawiania na oferty Allegro">
              <>
                <AllegroFormButton
                  setOpenAllegroFormPopup={setOpenAllegroFormPopup}
                  isAssigned={assignedPortals.includes(allegroPlatform.platformName)}
                />
                {openAllegroPopup && (
                  <AllegroFormPopup
                    closeAllegroPopup={() => setOpenAllegroFormPopup(false)}
                    onSubmit={onAllegroFormSubmit}
                  />
                )}
              </>
            </BasicTooltip>
          )}
          {ebayPlatform && platformConnections.includes(ebayPlatform.platformId) && (
            <BasicTooltip title="Stwórz formularz wystawiania oferty na Ebay">
              <>
                <EbayFormButton
                  setOpenEbayFormPopup={setOpenEbayFormPopup}
                  isAssigned={assignedPortals.includes(ebayPlatform.platformName)}
                />
                {openEbayPopup && (
                  <EbayFormPopup
                    closePopup={() => setOpenEbayFormPopup(false)}
                    onSubmit={onEbayFormSubmit}
                  />
                )}
              </>
            </BasicTooltip>
          )}
        </div>
      </div>
    </>
  );
}

export default AuctionPortals;
