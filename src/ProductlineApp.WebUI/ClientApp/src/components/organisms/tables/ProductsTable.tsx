import './css/ProductsTable.css';
import { ProductsTableHeader } from '../../molecules/table/headers/ProductsTableHeader';
import { ProductsTableBody } from '../../molecules/table/bodys/ProductsTableBody';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { ProductsHederActions } from '../../molecules/table/headersActions/ProductsHederActions';
import { ProductsRecord } from '../../../interfaces/products/ProductsPageInteface';
import { CircularProgress } from '@mui/material';

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
  return (
    <>
      <ProductsHederActions searchValue={searchValue} onChange={onChange} />
      <table className="products">
        <ProductsTableHeader />
        <ProductsTableBody productRecords={productRecords} onProductDelete={onProductDelete} />
      </table>
      {!productRecords && <CircularProgress />}
      <TableFooter />
    </>
  );
}
