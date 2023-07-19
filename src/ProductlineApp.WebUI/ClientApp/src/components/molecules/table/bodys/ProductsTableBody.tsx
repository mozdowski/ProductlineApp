import './css/ProductsTableBody.css';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';
import { ProductsTableRow } from '../rows/productsTableRow';

export const ProductsTableBody = ({
  productRecords,
  onProductDelete,
}: {
  productRecords?: ProductsRecord[];
  onProductDelete: (productId: string) => void;
}) => {
  return (
    <tbody>
      {productRecords &&
        productRecords.map((product, key) => (
          <ProductsTableRow key={key} product={product} onProductDelete={onProductDelete} />
        ))}
    </tbody>
  );
};
