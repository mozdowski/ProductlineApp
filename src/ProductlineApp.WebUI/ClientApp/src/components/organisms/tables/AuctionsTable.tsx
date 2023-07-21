import './css/AuctionsTable.css';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { AuctionsRecord } from '../../../interfaces/auctions/AuctionsPageInteface';
import { AuctionsHederActions } from '../../molecules/table/headersActions/AuctionsHederActions';
import { AuctionsTableHeader } from '../../molecules/table/headers/AuctionsTableHeader';
import { AuctionsTableBody } from '../../molecules/table/bodys/AuctionsTableBody';
import { CircularProgress } from '@mui/material';
import { useEffect, useState } from 'react';

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
  const [page, setPage] = useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);
  const [totalPages, setTotalPages] = useState<number>(0);

  useEffect(() => {
    if (auctionRecords) {
      const totalPages = Math.ceil(auctionRecords.length / rowsPerPage);
      setTotalPages(totalPages);
    }
  }, [auctionRecords, rowsPerPage]);

  const handleChangeRowsPerPage = (rowsCount: number) => {
    setRowsPerPage(rowsCount);
    setPage(0);
  };

  const handlePageChange = (pageNumber: number) => {
    setPage(pageNumber - 1);
  };

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
            page={page}
            rowsPerPage={rowsPerPage}
          />
        )}
      </table>
      {(!auctionRecords || !isDataLoaded) && <CircularProgress sx={{ alignSelf: 'center' }} />}
      <TableFooter
        totalPages={totalPages}
        currentPage={page + 1}
        currentRowsCount={rowsPerPage}
        onPageChange={handlePageChange}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </>
  );
}
