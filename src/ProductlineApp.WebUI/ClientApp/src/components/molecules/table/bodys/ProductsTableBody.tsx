import './css/ProductsTableBody.css';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';
import { ProductsTableRow } from '../rows/productsTableRow';

export const ProductsTableBody = ({ productRecords }: { productRecords?: ProductsRecord[] }) => {
  return (
    <tbody>
      {productRecords &&
        productRecords.map((product, key) => <ProductsTableRow key={key} product={product} />)}
    </tbody>
  );
};
