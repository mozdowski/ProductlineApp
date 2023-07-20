import './css/ProductsTable.css';
import { ProductsTableHeader } from '../../molecules/table/headers/ProductsTableHeader';
import { ProductsTableBody } from '../../molecules/table/bodys/ProductsTableBody';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { ProductsHederActions } from '../../molecules/table/headersActions/ProductsHederActions';
import { ProductsRecord } from '../../../interfaces/products/ProductsPageInteface';
import { CircularProgress } from '@mui/material';
import { useEffect, useState } from 'react';

export default function ProductsTable({
  productRecords,
  searchValue,
  onChange,
  onProductDelete,
}: {
  productRecords?: ProductsRecord[];
  searchValue: string;
  onChange: (e: any) => void;
  onProductDelete: (productId: string) => void;
}) {
  const [page, setPage] = useState<number>(0);
  const [rowsPerPage, setRowsPerPage] = useState<number>(5);
  const [totalPages, setTotalPages] = useState<number>(0);

  useEffect(() => {
    if (productRecords) {
      const totalPages = Math.ceil(productRecords.length / rowsPerPage);
      setTotalPages(totalPages);
    }
  }, [productRecords, rowsPerPage]);

  const handleChangeRowsPerPage = (rowsCount: number) => {
    setRowsPerPage(rowsCount);
    setPage(0);
  };

  const handlePageChange = (pageNumber: number) => {
    setPage(pageNumber - 1);
  };

  return (
    <>
      <ProductsHederActions searchValue={searchValue} onChange={onChange} />
      <table className="products">
        <ProductsTableHeader />
        <ProductsTableBody
          productRecords={productRecords}
          onProductDelete={onProductDelete}
          page={page}
          rowsPerPage={rowsPerPage}
        />
      </table>
      {!productRecords && <CircularProgress />}
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
