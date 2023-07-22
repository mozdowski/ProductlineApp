import './css/OrdersTable.css';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { OrdersRecord } from '../../../interfaces/orders/OrdersPageInteface';
import { OrdersHederActions } from '../../molecules/table/headersActions/OrdersHederActions';
import { OrdersTableHeader } from '../../molecules/table/headers/OrdersTableHeader';
import { OrdersTableBody } from '../../molecules/table/bodys/OrdersTableBody';
import { CircularProgress } from '@mui/material';
import { OrderStatus } from '../../../enums/orderStatus.enum';
import { useEffect, useState } from 'react';

export default function OrdersTable({
  orderRecords,
  showCompletedOrders,
  handleClickTypeOrdersButton,
  searchValue,
  onChange,
  markOrderAsCompleted,
}: {
  orderRecords?: OrdersRecord[];
  showCompletedOrders: boolean;
  handleClickTypeOrdersButton: (showCompleted: boolean) => void;
  searchValue: string;
  onChange: (e: any) => void;
  markOrderAsCompleted: (orderId: string) => void;
}) {
  const [page, setPage] = useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);
  const [totalPages, setTotalPages] = useState<number>(0);

  useEffect(() => {
    if (orderRecords) {
      const totalPages = Math.ceil(orderRecords.length / rowsPerPage);
      setTotalPages(totalPages);
    }
  }, [orderRecords, rowsPerPage]);

  const handleChangeRowsPerPage = (rowsCount: number) => {
    setRowsPerPage(rowsCount);
    setPage(0);
  };

  const handlePageChange = (pageNumber: number) => {
    setPage(pageNumber - 1);
  };

  return (
    <>
      <OrdersHederActions
        showCompletedOrders={showCompletedOrders}
        handleClickTypeOrdersButton={handleClickTypeOrdersButton}
        searchValue={searchValue}
        onChange={onChange}
      />
      <table className="orders">
        <OrdersTableHeader />
        <OrdersTableBody
          orderRecords={orderRecords}
          showCompletedOrders={showCompletedOrders}
          markOrderAsCompleted={markOrderAsCompleted}
          page={page}
          rowsPerPage={rowsPerPage}
        />
      </table>
      {!orderRecords && <CircularProgress />}
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
