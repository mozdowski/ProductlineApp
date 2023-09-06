import { useCallback, useState } from 'react';
import './css/AuctionsTableBody.css';
import { AuctionsRecord } from '../../../../interfaces/auctions/AuctionsPageInteface';
import { AuctionsTableRow } from '../rows/auctionsTableRow';

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
  page,
  rowsPerPage,
  onAuctionReactivate,
}: {
  auctionRecords: AuctionsRecord[];
  onEditAuction: (auctionId: string) => Promise<boolean>;
  onWithdrawAuction: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
  showActiveAuctions: boolean;
  page: number;
  rowsPerPage: number;
  onAuctionReactivate: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
}) => {
  return (
    <>
      <tbody>
        {auctionRecords
          .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
          .map(
            (auction, key) =>
              auction && (
                <AuctionsTableRow
                  key={key}
                  auction={auction}
                  onEditAuction={onEditAuction}
                  onWithdrawAuction={onWithdrawAuction}
                  onAuctionReactivate={onAuctionReactivate}
                />
              ),
          )}
      </tbody>
    </>
  );
};
