import React from 'react';
import './css/ProductAuctionLinksSection.css';
import EbayLink from '../../atoms/links/EbayLink';
import { PlatformEnum } from '../../../enums/platform.enum';
import AllegroLink from '../../atoms/links/AllegroLink';

function ProductAuctionLinksSection({ platformsListedOn }: { platformsListedOn: PlatformEnum[] }) {
  return (
    <div className="productExposedOnSection">
      {Array.from(new Set(platformsListedOn)).map((item, key) => (
        <>
          {item === PlatformEnum.EBAY && <EbayLink />}
          {item === PlatformEnum.ALLEGRO && <AllegroLink />}
        </>
      ))}
    </div>
  );
}

export default ProductAuctionLinksSection;
