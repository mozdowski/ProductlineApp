import React, { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import { CollapseAuctionDetails } from './CollapseAuctionDetails';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import BackAuctionIcon from '../../../../assets/icons/backAuction_icon.png';
import './css/AuctionsTableBody.css';
import { AuctionsRecord } from '../../../../interfaces/auctions/AuctionsPageInteface';

export default function openCollapse(init: any) {
  const [isOpen, setOpenState] = useState(init);

  const toggle = useCallback(() => {
    setOpenState((state: any) => !state);
  }, [setOpenState]);

  return { isOpen, toggle };
}

export const AuctionsTableBody = ({
  auctionRecords,
  onEditAuction,
  onWithdrawAuction,
  showActiveAuctions,
}: {
  auctionRecords: AuctionsRecord[];
  onEditAuction: (auctionId: string) => void;
  onWithdrawAuction: (auctionId: string) => void;
  showActiveAuctions: boolean;
}) => {
  const { isOpen, toggle } = openCollapse(false);

  return (
    <>
      <tbody>
        <tr className="AuctionsTableRow">
          <td>
            <CollapseTableButton isOpen={isOpen} toggle={toggle} />
          </td>
          {auctionRecords.map(
            (auction, key) =>
              auction &&
              auction.isActive == showActiveAuctions && (
                <React.Fragment key={key}>
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
                  <td>{auction?.daysToEnd ? auction?.daysToEnd : '-'}</td>
                  <td>
                    <div className="auctionsButtonsAction">
                      <img
                        className="editAuctionIcon"
                        src={EditIcon}
                        onClick={() => onEditAuction(auction.auctionID)}
                      />
                      <img
                        className="backAuctionIcon"
                        src={BackAuctionIcon}
                        onClick={() => onWithdrawAuction(auction.auctionID)}
                      />
                    </div>
                  </td>
                </React.Fragment>
              ),
          )}
        </tr>
        {isOpen && <CollapseAuctionDetails isOpen={isOpen} auctionRecords={auctionRecords} />}
      </tbody>
    </>
  );
};
