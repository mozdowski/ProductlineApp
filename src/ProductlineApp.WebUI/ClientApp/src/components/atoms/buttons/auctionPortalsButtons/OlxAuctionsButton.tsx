import React, { useState } from 'react';
import OlxIcon from '../../../../assets/icons/olx_icon1.svg';
import './css/olxAuctionsButton.css';

function OlxAuctionsButton({
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
      className={isSelectedAuctionPortal === 'olx' ? 'olxButton selected' : 'olxButton'}
      onClick={handleClickTypeAuctionPortalButton}
    >
      <img className="olxIcon" src={OlxIcon} />
    </div>
  );
}

export default OlxAuctionsButton;
