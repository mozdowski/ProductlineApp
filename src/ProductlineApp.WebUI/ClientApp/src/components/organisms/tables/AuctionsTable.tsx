import './css/AuctionsTable.css';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { AuctionsRecord } from '../../../interfaces/auctions/AuctionsPageInteface';
import { AuctionsHederActions } from '../../molecules/table/headersActions/AuctionsHederActions';
import { AuctionsTableHeader } from '../../molecules/table/headers/AuctionsTableHeader';
import { AuctionsTableBody } from '../../molecules/table/bodys/AuctionsTableBody';

export default function AuctionsTable({
  auctionRecords,
  isSelectedTypeAuctions,
  handleClickTypeAuctionsButton,
}: {
  auctionRecords: AuctionsRecord[];
  isSelectedTypeAuctions: any;
  handleClickTypeAuctionsButton: any;
}) {
  return (
    <>
      <AuctionsHederActions
        isSelectedTypeAuctions={isSelectedTypeAuctions}
        handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
      />
      <table className="auctions">
        <AuctionsTableHeader />
        <AuctionsTableBody auctionRecords={auctionRecords} />
      </table>
      <TableFooter />
    </>
  );
}
