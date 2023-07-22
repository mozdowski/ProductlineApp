import React from 'react';
import './css/AuctionsHederActions.css';
import Searchbar from '../../../atoms/inputs/searchbarInput/Searchbar';
import ActiveAuctionButton from '../../../atoms/buttons/activeAuctionsButton/ActiveAuctionsButton';
import EndAuctionButton from '../../../atoms/buttons/endAuctionsButton/EndAuctionButton';
import AddAuctionButton from '../../../atoms/buttons/addAuctionButton/AddAuctionButton';

export const AuctionsHederActions = ({
  showActiveAuctions,
  onAuctionStateClick,
  searchValue,
  onChange,
}: {
  showActiveAuctions: boolean;
  onAuctionStateClick: (showActive: boolean) => void;
  searchValue: any;
  onChange: (e: any) => void;
}) => {
  return (
    <>
      <div className="AuctionsTableButtons">
        <div className="changeTypeAuctionsButtons">
          <ActiveAuctionButton
            id={'active'}
            showActiveAuctions={showActiveAuctions}
            onAuctionStateClick={onAuctionStateClick}
          />
          <EndAuctionButton
            id={'ended'}
            showActiveAuctions={showActiveAuctions}
            onAuctionStateClick={onAuctionStateClick}
          />
        </div>
        <div className="AuctionsTableActionButtons">
          <Searchbar searchValue={searchValue} onChange={onChange} />
          <AddAuctionButton />
        </div>
      </div>
    </>
  );
};
