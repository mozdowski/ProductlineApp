import React, { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import { CollapseProductDetails } from './CollapseProductDetails';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import DeleteProductIcon from '../../../../assets/icons/delete_icon.svg';
import './css/ProductsTableBody.css';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';

export default function openCollapse(init: boolean) {
  const [isOpen, setOpenState] = useState(init);

  const toggle = useCallback(() => {
    setOpenState((state: boolean) => !state);
  }, [setOpenState]);

  return { isOpen, toggle };
}

export const ProductsTableBody = ({ productRecords }: { productRecords: ProductsRecord[] }) => {
  const { isOpen, toggle } = openCollapse(false);

  return (
    <tbody>
      <tr className="ProductsTableRow">
        <td>
          <CollapseTableButton isOpen={isOpen} toggle={toggle} />
        </td>
      </tr>
      {productRecords.map((product, index) => (
        <React.Fragment key={index}>
          <tr className="ProductsTableRow">
            <td>{product.sku}</td>
            <td>{product.brand}</td>
            <td>
              <div className="productName">
                <img className="productImage" src={product?.imageUrl} alt="product img" />
                <p>{product.productName}</p>
              </div>
            </td>
            <td>{product.category}</td>
            <td>{product.price} zł</td>
            <td>{product.quantity}</td>
            <td className="productStatus productExposed">{product.condition}</td>
            <td>
              <div className="productsButtonsAction">
                <img className="editProductIcon" src={EditIcon} alt="Edit Icon" />
                <img className="deleteProductIcon" src={DeleteProductIcon} alt="Delete Icon" />
              </div>
            </td>
          </tr>
        </React.Fragment>
      ))}
      {isOpen && (
        <React.Fragment key="details">
          <tr className="ProductsTableRow">
            <td colSpan={8}>
              <CollapseProductDetails isOpen={isOpen} productRecords={productRecords} />
            </td>
          </tr>
        </React.Fragment>
      )}
    </tbody>
  );
};
