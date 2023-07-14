import './css/AuctionsTable.css';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { AuctionsRecord } from '../../../interfaces/auctions/AuctionsPageInteface';
import { AuctionsHederActions } from '../../molecules/table/headersActions/AuctionsHederActions';
import { AuctionsTableHeader } from '../../molecules/table/headers/AuctionsTableHeader';
import { AuctionsTableBody } from '../../molecules/table/bodys/AuctionsTableBody';
import { CircularProgress } from '@mui/material';

export default function AuctionsTable({
  auctionRecords,
  showActiveAuctions,
  handleClickTypeAuctionsButton,
  onEditAuction,
  onWithdrawAuction,
}: {
  auctionRecords?: AuctionsRecord[];
  showActiveAuctions: boolean;
  handleClickTypeAuctionsButton: any;
  onEditAuction: (auctionId: string) => void;
  onWithdrawAuction: (auctionId: string) => void;
}) {
  return (
    <>
      <AuctionsHederActions
        showActiveAuctions={showActiveAuctions}
        handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
      />
      <table className="auctions">
        <AuctionsTableHeader />
        {auctionRecords && auctionRecords.length > 0 && (
          <AuctionsTableBody
            showActiveAuctions={showActiveAuctions}
            auctionRecords={auctionRecords}
            onEditAuction={onEditAuction}
            onWithdrawAuction={onWithdrawAuction}
          />
        )}
      </table>
      {!auctionRecords && <CircularProgress sx={{ alignSelf: 'center' }} />}
      <TableFooter />
    </>
  );
}
