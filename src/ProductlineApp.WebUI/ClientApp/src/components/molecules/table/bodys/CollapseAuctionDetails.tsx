import React from 'react';
import './css/CollapseAuctionDetails.css';

export const CollapseAuctionDetails = ({
  daysToEnd
}: {
  daysToEnd: number | undefined
}) => {
  return (
    <tr className="auctionDetailsWrapper">
      <td></td>
      <td colSpan={2}>
        <div className="auctonDaysToEndSection">
          <h1>Wygasa za: </h1>
          <h2>{daysToEnd}</h2>
        </div>
      </td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
  );
};
