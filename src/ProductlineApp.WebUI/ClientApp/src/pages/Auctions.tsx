import AuctionsTemplate from '../components/templates/AuctionsTemplate';
import { useState } from 'react';

export default function Auctions() {
  const [isSelectedAuctionPortal, setIsSelectedAuctionPortal] = useState('');
  const handleClickTypeAuctionPortalButton = (e: any) => {
    setIsSelectedAuctionPortal(e.target.id);
  };

  const [isSelectedTypeAuctions, SetisSelectedTypeAuctions] = useState('');
  const handleClickTypeAuctionsButton = (e: any) => {
    SetisSelectedTypeAuctions(e.target.id);
  };

  return (
    <AuctionsTemplate
      auctionRecords={[]}
      isSelectedAuctionPortal={isSelectedAuctionPortal}
      handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
      isSelectedTypeAuctions={isSelectedTypeAuctions}
      handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
    />
  );
}
