import { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import BackAuctionIcon from '../../../../assets/icons/backAuction_icon.png';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import { AuctionsRecord } from '../../../../interfaces/auctions/AuctionsPageInteface';
import { CollapseAuctionDetails } from '../bodys/CollapseAuctionDetails';
import { CircularProgress } from '@mui/material';
import BasicTooltip from '../../../atoms/common/tooltip/basicTooltip';

enum AuctionActionType {
  WITHDRAW,
  REACTIVATE,
  DELETE,
}

export const AuctionsTableRow = ({
  auction,
  onEditAuction,
  onWithdrawAuction,
  onAuctionReactivate,
}: {
  auction: AuctionsRecord;
  onEditAuction: (auctionId: string) => Promise<boolean>;
  onWithdrawAuction: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
  onAuctionReactivate: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
}) => {
  const [isOpen, setOpenState] = useState<boolean>(false);
  const [isEditLoading, setIsEditLoading] = useState<boolean>(false);
  const [isWithdrawLoading, setIsWithdrawLoading] = useState<boolean>(false);
  const [isReactivateLoading, setIsReactivateLoading] = useState<boolean>(false);

  const [allowBackAuction, setAllowBackAuction] = useState<boolean>(true);
  const [selectedActionType, setSelectedActionType] = useState<AuctionActionType | undefined>(
    undefined,
  );

  const handleClickAuctionButtonsActions = (actionType?: AuctionActionType) => {
    setSelectedActionType(actionType);
    setAllowBackAuction(!allowBackAuction);
  };

  const [allowDelete, setAllowDelete] = useState(true);

  const handleClickAllowDelete = () => {
    setAllowDelete(!allowDelete);
  };

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

  const handleOnReactivateClick = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => {
    setIsReactivateLoading(true);
    const isLoaded = await onAuctionReactivate(listingId, listingInstanceId, auctionId);
    setIsReactivateLoading(!isLoaded);
  };

  const handleAcceptActionClick = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => {
    switch (selectedActionType) {
      case AuctionActionType.WITHDRAW: {
        const res = await handleOnWithdrawClick(listingId, listingInstanceId, auctionId);
        break;
      }
      case AuctionActionType.REACTIVATE: {
        const res = await handleOnReactivateClick(listingId, listingInstanceId, auctionId);
        break;
      }
    }
  };

  return (
    <React.Fragment>
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
            {!allowBackAuction ? (
              <>
                <div className="cancelBackAuctionButton">
                  <span
                    className="cancelBackAuctionIcon cancelTableIcon"
                    onClick={() => handleClickAuctionButtonsActions()}
                  />
                </div>
                <div className="acceptBackAuctionButton">
                  <span
                    className="acceptBackAuctionIcon assignTableIcon"
                    onClick={() =>
                      handleAcceptActionClick(
                        auction.listingId,
                        auction.listingInstanceId,
                        auction.auctionID,
                      )
                    }
                  />
                </div>
              </>
            ) : (
              <>
                {!isEditLoading && (
                  <BasicTooltip title="Edytuj aukcję">
                    <img className="editAuctionIcon" src={EditIcon} onClick={handleOnEditClick} />
                  </BasicTooltip>
                )}
                {isEditLoading && <CircularProgress size={22} sx={{ marginRight: '8px' }} />}

                {auction.isActive ? (
                  <>
                    {!isWithdrawLoading && (
                      <BasicTooltip title="Wycofaj aukcję">
                        <img
                          className="backAuctionIcon"
                          src={BackAuctionIcon}
                          onClick={() =>
                            handleClickAuctionButtonsActions(AuctionActionType.WITHDRAW)
                          }
                        />
                      </BasicTooltip>
                    )}
                    {isWithdrawLoading && (
                      <CircularProgress size={22} sx={{ marginRight: '8px', color: "var(--first-color)" }} />
                    )}
                  </>
                ) : (
                  <>
                    {!isReactivateLoading && (
                      <BasicTooltip title="Wznów aukcję">
                        <div className="refreshAuctionButton">
                          <span
                            className="refreshAuctionIcon refreshAuctionIcon"
                            onClick={() =>
                              handleClickAuctionButtonsActions(AuctionActionType.REACTIVATE)
                            }
                          />
                        </div>
                      </BasicTooltip>
                    )}
                    {isReactivateLoading && (
                      <CircularProgress size={22} sx={{ marginRight: '8px', color: "var(--first-color)" }} />
                    )}
                    {/* <img className="deleteAuctionIcon" src={DeleteAuctionIcon} alt="Delete Icon" onClick={handleClickAllowDelete} /> */}
                  </>
                )}
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
