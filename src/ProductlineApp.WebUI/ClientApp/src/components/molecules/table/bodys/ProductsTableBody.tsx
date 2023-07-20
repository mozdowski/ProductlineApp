import './css/ProductsTableBody.css';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';
import { ProductsTableRow } from '../rows/productsTableRow';

export const ProductsTableBody = ({
  productRecords,
  onProductDelete,
  page,
  rowsPerPage,
}: {
  productRecords?: ProductsRecord[];
  onProductDelete: (productId: string) => void;
  page: number;
  rowsPerPage: number;
}) => {
  return (
    <tbody>
      {productRecords &&
        productRecords
          .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
          .map((product, key) => (
            <ProductsTableRow key={key} product={product} onProductDelete={onProductDelete} />
          ))}
    </tbody>
  );
};
