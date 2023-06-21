import React from 'react';
import './css/ProductAuctionLinksSection.css';
import EbayLink from '../../atoms/links/EbayLink';
import OlxLink from '../../atoms/links/OlxLink';
import AmazonLink from '../../atoms/links/AmazonLink';

function ProductAuctionLinksSection() {
  return (
    <div className="productExposedOnSection">
      <EbayLink />
      <AmazonLink />
      <OlxLink />
    </div>
  );
}

export default ProductAuctionLinksSection;
