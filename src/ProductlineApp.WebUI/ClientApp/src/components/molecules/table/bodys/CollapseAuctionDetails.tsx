import React from 'react';
import './css/CollapseAuctionDetails.css';
import { AuctionsRecord } from '../../../../interfaces/auctions/AuctionsPageInteface';

export const CollapseAuctionDetails = ({
  isOpen,
  auctionRecords,
}: {
  isOpen: any;
  auctionRecords: AuctionsRecord[];
}) => {
  return (
    <tr className="auctionDetailsWrapper">
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
  );
};
