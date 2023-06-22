import React from 'react';
import './css/ProductAuctionLinksSection.css';
import EbayLink from '../../atoms/links/EbayLink';
import OlxLink from '../../atoms/links/OlxLink';
import AmazonLink from '../../atoms/links/AmazonLink';
import { PlatformEnum } from '../../../enums/platform.enum';

function ProductAuctionLinksSection({ platformsListedOn }: { platformsListedOn: PlatformEnum[] }) {
  return (
    <div className="productExposedOnSection">
      {platformsListedOn.map((item, key) => (
        <>
          {item === PlatformEnum.EBAY && <EbayLink />}
          {item === PlatformEnum.OLX && <OlxLink />}
          {item === PlatformEnum.AMAZON && <AmazonLink />}
        </>
      ))}
    </div>
  );
}

export default ProductAuctionLinksSection;
