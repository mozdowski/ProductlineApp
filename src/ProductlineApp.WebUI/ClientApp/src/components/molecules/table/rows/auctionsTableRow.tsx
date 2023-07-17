import { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import BackAuctionIcon from '../../../../assets/icons/backAuction_icon.png';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import { AuctionsRecord } from '../../../../interfaces/auctions/AuctionsPageInteface';
import { CollapseAuctionDetails } from '../bodys/CollapseAuctionDetails';
import { CircularProgress } from '@mui/material';

export const AuctionsTableRow = ({
  key,
  auction,
  onEditAuction,
  onWithdrawAuction,
}: {
  auction: AuctionsRecord;
  key: string | number;
  onEditAuction: (auctionId: string) => Promise<boolean>;
  onWithdrawAuction: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
}) => {
  const [isOpen, setOpenState] = useState<boolean>(false);
  const [isEditLoading, setIsEditLoading] = useState<boolean>(false);
  const [isWithdrawLoading, setIsWithdrawLoading] = useState<boolean>(false);

  const toggle = useCallback(() => {
    setOpenState((state: boolean) => !state);
  }, [setOpenState]);

  const handleOnEditClick = async () => {
    setIsEditLoading(true);
    const isLoaded = await onEditAuction(auction.auctionID);
    setIsEditLoading(!isLoaded);
  };

  const handleOnWithdrawClick = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => {
    setIsWithdrawLoading(true);
    const isLoaded = await onWithdrawAuction(listingId, listingInstanceId, auctionId);
    setIsWithdrawLoading(!isLoaded);
  };

  return (
    <React.Fragment key={key}>
      <tr className="AuctionsTableRow">
        <td>{auction.isActive ? <CollapseTableButton isOpen={isOpen} toggle={toggle} /> : ''}</td>
        <td>{auction?.auctionID}</td>
        <td>{auction?.sku}</td>
        <td>{auction?.brand}</td>
        <td>
          <div className="productName">
            <img className="productImage" src={auction?.productImageUrl}></img>
            <p>{auction?.productName}</p>
          </div>
        </td>
        <td>{auction?.category}</td>
        <td>{auction?.price} zł</td>
        <td>{auction?.quantity}</td>
        <td>
          <div className="auctionsButtonsAction">
            {auction.isActive && (
              <>
                {!isEditLoading && (
                  <img className="editAuctionIcon" src={EditIcon} onClick={handleOnEditClick} />
                )}
                {isEditLoading && <CircularProgress size={22} sx={{ marginRight: '8px' }} />}
                <img
                  className="backAuctionIcon"
                  src={BackAuctionIcon}
                  onClick={() =>
                    handleOnWithdrawClick(
                      auction.listingId,
                      auction.listingInstanceId,
                      auction.auctionID,
                    )
                  }
                />
                {isWithdrawLoading && <CircularProgress size={22} />}
              </>
            )}
          </div>
        </td>
      </tr>
      {isOpen && (
        <React.Fragment key="details">
          {auction.isActive ? <CollapseAuctionDetails daysToEnd={auction?.daysToEnd} /> : ' '}
        </React.Fragment>
      )}
    </React.Fragment>
  );
};
