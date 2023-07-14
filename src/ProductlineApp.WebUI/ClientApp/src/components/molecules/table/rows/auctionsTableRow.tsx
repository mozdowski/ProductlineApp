import { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import BackAuctionIcon from '../../../../assets/icons/backAuction_icon.png';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import { AuctionsRecord } from '../../../../interfaces/auctions/AuctionsPageInteface';
import { CollapseAuctionDetails } from '../bodys/CollapseAuctionDetails';

export const AuctionsTableRow = ({
  key,
  auction,
}: {
  auction: AuctionsRecord;
  key: string | number;
}) => {
  const [isOpen, setOpenState] = useState<boolean>(false);

  const toggle = useCallback(() => {
    setOpenState((state: boolean) => !state);
  }, [setOpenState]);

  return (
    <React.Fragment key={key}>
      <tr className="AuctionsTableRow">
        <td>
          <CollapseTableButton isOpen={isOpen} toggle={toggle} />
        </td>
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
            <img className="editAuctionIcon" src={EditIcon} />
            <img className="backAuctionIcon" src={BackAuctionIcon} />
          </div>
        </td>
      </tr>
      {isOpen && (
        <React.Fragment key="details">
          <CollapseAuctionDetails daysToEnd={auction?.daysToEnd} />
        </React.Fragment>
      )}
    </React.Fragment>
  );
};
