import React from 'react';
import EbayIcon from '../../../assets/icons/ebay_icon1.svg';
import './css/EbayLink.css';

function EbayLink() {
  return (
    <a href="https://www.ebay.pl" target="_blank" rel="noopener noreferrer" className="ebayLink">
      <img src={EbayIcon} className="ebayIcon"></img>
    </a>
  );
}

export default EbayLink;
