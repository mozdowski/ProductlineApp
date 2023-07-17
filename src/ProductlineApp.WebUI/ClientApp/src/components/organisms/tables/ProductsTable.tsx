import './css/ProductsTable.css';
import { ProductsTableHeader } from '../../molecules/table/headers/ProductsTableHeader';
import { ProductsTableBody } from '../../molecules/table/bodys/ProductsTableBody';
import { TableFooter } from '../../molecules/table/footers/TableFooter';
import { ProductsHederActions } from '../../molecules/table/headersActions/ProductsHederActions';
import { ProductsRecord } from '../../../interfaces/products/ProductsPageInteface';

export default function ProductsTable({
  productRecords,
  searchValue,
  onChange,
}: {
  productRecords: ProductsRecord[];
  searchValue: string;
  onChange: (e: any) => void;
}) {
  return (
    <>
      <ProductsHederActions searchValue={searchValue} onChange={onChange} />
      <table className="products">
        <ProductsTableHeader />
        <ProductsTableBody productRecords={productRecords} />
      </table>
      <TableFooter />
    </>
  );
}
