import React from 'react';
import EbayIcon from '../../../assets/icons/ebay_icon.svg';
import './css/EbayLink.css';

function EbayLink() {
  return (
    <a href="https://www.ebay.pl" target="_blank" rel="noopener noreferrer" className="ebayLink">
      <div className="ebayLinkProductButton">
        <span className="ebayLinkProductIcon ebayProductLinkIcon" />
      </div>
    </a>
  );
}

export default EbayLink;
