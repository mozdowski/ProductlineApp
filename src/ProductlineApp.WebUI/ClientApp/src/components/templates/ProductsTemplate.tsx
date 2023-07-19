import './css/ProductsTemplate.css';
import ProductsTable from '../organisms/tables/ProductsTable';
import { ProductsRecord } from '../../interfaces/products/ProductsPageInteface';
import ProductsPageHeader from '../organisms/pageHeaders/ProductsPageHeader';

export default function ProductsTemplate({
  productRecords,
  searchValue,
  onChange,
}: {
  productRecords?: ProductsRecord[];
  searchValue: string;
  onChange: (e: any) => void;
}) {
  return (
    <>
      <ProductsPageHeader />
      <div className="content">
        <div className="tableProducts">
          <ProductsTable
            productRecords={productRecords}
            searchValue={searchValue}
            onChange={onChange}
          />
        </div>
      </div>
    </>
  );
}
