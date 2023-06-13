import { useCallback, useState } from 'react';
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

export const AuctionsTableBody = ({ auctionRecords }: { auctionRecords: AuctionsRecord[] }) => {
  const { isOpen, toggle } = openCollapse(false);

  return (
    <>
      <tbody>
        <tr className="AuctionsTableRow">
          <td>
            <CollapseTableButton isOpen={isOpen} toggle={toggle} />
          </td>
          {auctionRecords.map((auction, key) => (
            <>
              <td key={key}>{auction.AuctionID}</td>
              <td>{auction.SKU}</td>
              <td>{auction.Brand}</td>
              <td>
                <div className="productName">
                  <div className="productImage"></div>
                  <p>{auction.ProductName}</p>
                </div>
              </td>
              <td>{auction.Category}</td>
              <td>{auction.Price} zł</td>
              <td>{auction.Quantity}</td>
              <td>{auction.DaysToEnd}</td>
            </>
          ))}
          <td>
            <div className="auctionsButtonsAction">
              <img className="editAuctionIcon" src={EditIcon} />
              <img className="backAuctionIcon" src={BackAuctionIcon} />
            </div>
          </td>
        </tr>
        {isOpen && <CollapseAuctionDetails isOpen={isOpen} auctionRecords={auctionRecords} />}
      </tbody>
    </>
  );
};
