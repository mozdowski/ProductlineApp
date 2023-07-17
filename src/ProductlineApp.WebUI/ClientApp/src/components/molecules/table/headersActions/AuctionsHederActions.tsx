import React from 'react';
import './css/AuctionsHederActions.css';
import Searchbar from '../../../atoms/inputs/searchbarInput/Searchbar';
import ActiveAuctionButton from '../../../atoms/buttons/activeAuctionsButton/ActiveAuctionsButton';
import EndAuctionButton from '../../../atoms/buttons/endAuctionsButton/EndAuctionButton';
import AddAuctionButton from '../../../atoms/buttons/addAuctionButton/AddAuctionButton';

export const AuctionsHederActions = ({
  showActiveAuctions,
  handleClickTypeAuctionsButton,
  searchValue,
  onChange,
}: {
  showActiveAuctions: boolean;
  handleClickTypeAuctionsButton: any;
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
            handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
          />
          <EndAuctionButton
            id={'ended'}
            showActiveAuctions={showActiveAuctions}
            handleClickTypeAuctionButton={handleClickTypeAuctionsButton}
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
