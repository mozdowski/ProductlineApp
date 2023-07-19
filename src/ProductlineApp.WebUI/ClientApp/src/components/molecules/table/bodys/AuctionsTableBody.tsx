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
}: {
  auctionRecords: AuctionsRecord[];
  onEditAuction: (auctionId: string) => Promise<boolean>;
  onWithdrawAuction: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
  showActiveAuctions: boolean;
}) => {
  return (
    <>
      <tbody>
        {auctionRecords.map(
          (auction, key) =>
            auction &&
            auction.isActive == showActiveAuctions && (
              <AuctionsTableRow
                key={key}
                auction={auction}
                onEditAuction={onEditAuction}
                onWithdrawAuction={onWithdrawAuction}
              />
            ),
        )}
      </tbody>
    </>
  );
};
