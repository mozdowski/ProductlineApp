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
  searchValue,
  onChange,
  isDataLoaded,
}: {
  auctionRecords?: AuctionsRecord[];
  showActiveAuctions: boolean;
  handleClickTypeAuctionsButton: any;
  onEditAuction: (auctionId: string) => Promise<boolean>;
  onWithdrawAuction: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
  searchValue: string;
  onChange: (e: any) => void;
  isDataLoaded: boolean;
}) {
  return (
    <>
      <AuctionsHederActions
        showActiveAuctions={showActiveAuctions}
        handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
        searchValue={searchValue}
        onChange={onChange}
      />
      <table className="auctions">
        <AuctionsTableHeader />
        {auctionRecords && isDataLoaded && auctionRecords.length > 0 && (
          <AuctionsTableBody
            showActiveAuctions={showActiveAuctions}
            auctionRecords={auctionRecords}
            onEditAuction={onEditAuction}
            onWithdrawAuction={onWithdrawAuction}
          />
        )}
      </table>
      {(!auctionRecords || !isDataLoaded) && <CircularProgress sx={{ alignSelf: 'center' }} />}
      <TableFooter />
    </>
  );
}
