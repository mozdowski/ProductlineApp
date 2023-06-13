import { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import { CollapseProductDetails } from './CollapseProductDetails';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import DeleteProductIcon from '../../../../assets/icons/delete_icon.svg';
import './css/ProductsTableBody.css';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';

export default function openCollapse(init: any) {
  const [isOpen, setOpenState] = useState(init);

  const toggle = useCallback(() => {
    setOpenState((state: any) => !state);
  }, [setOpenState]);

  return { isOpen, toggle };
}

export const ProductsTableBody = ({ productRecords }: { productRecords: ProductsRecord[] }) => {
  const { isOpen, toggle } = openCollapse(false);

  return (
    <>
      <tbody>
        <tr className="ProductsTableRow">
          <td>
            <CollapseTableButton isOpen={isOpen} toggle={toggle} />
          </td>
          {productRecords.map((product, key) => (
            <>
              <td key={key}>{product.SKU}</td>
              <td>{product.Brand}</td>
              <td>
                <div className="productName">
                  <div className="productImage"></div>
                  <p>{product.ProductName}</p>
                </div>
              </td>
              <td>{product.Category}</td>
              <td>{product.Price} zł</td>
              <td>{product.Quantity}</td>
              <td className="productStatus productExposed">{product.Status}</td>
            </>
          ))}
          <td>
            <div className="productsButtonsAction">
              <img className="editProductIcon" src={EditIcon} />
              <img className="deleteProductIcon" src={DeleteProductIcon} />
            </div>
          </td>
        </tr>
        {isOpen && <CollapseProductDetails isOpen={isOpen} productRecords={productRecords} />}
      </tbody>
    </>
  );
};
