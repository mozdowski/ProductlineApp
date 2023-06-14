import React, { useState } from 'react';
import AmazonIcon from '../../../../assets/icons/amazon_icon1.svg';
import './css/amazonAuctionsButton.css';

function AmazonAuctionsButton({
  isSelectedAuctionPortal,
  handleClickTypeAuctionPortalButton,
  id,
}: {
  isSelectedAuctionPortal: any;
  handleClickTypeAuctionPortalButton: any;
  id: string;
}) {
  return (
    <div
      id={id}
      className={isSelectedAuctionPortal === 'amazon' ? 'amazonButton selected' : 'amazonButton'}
      onClick={handleClickTypeAuctionPortalButton}
    >
      <img className="amazonIcon" src={AmazonIcon} />
    </div>
  );
}

export default AmazonAuctionsButton;
