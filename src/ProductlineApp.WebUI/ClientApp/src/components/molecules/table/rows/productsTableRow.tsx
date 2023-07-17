import { useCallback, useState } from 'react';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import { CollapseProductDetails } from '../bodys/CollapseProductDetails';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import DeleteProductIcon from '../../../../assets/icons/delete_icon.svg';

export const ProductsTableRow = ({
  key,
  product,
}: {
  product: ProductsRecord;
  key: string | number;
}) => {
  const [isOpen, setOpenState] = useState<boolean>(false);

  const [allowDelete, setAllowDelete] = useState(true);

  const handleClickAllowDelete = () => {
    setAllowDelete(!allowDelete);
  };

  const toggle = useCallback(() => {
    setOpenState((state: boolean) => !state);
  }, [setOpenState]);

  return (
    <React.Fragment key={key}>
      <tr className="ProductsTableRow">
        <td>
          <CollapseTableButton isOpen={isOpen} toggle={toggle} />
        </td>
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
        <td
          className={`productStatus ${product.isListed && 'productExposed'} ${
            !product.isListed && 'productNotExposed'
          }`}
        >
          {product.listingStatus}
        </td>
        <td>
          <div className="productsButtonsAction">
            {!allowDelete ? (
              <>
                <div className="canceleDeleteProductButton">
                  <span
                    className="canceleDeleteProductIcon cancelTableIcon"
                    onClick={handleClickAllowDelete}
                  />
                </div>
                <div className="acceptDeleteProductButton">
                  <span
                    className="acceptDeleteProductIcon assignTableIcon"
                    onClick={handleClickAllowDelete}
                  />
                </div>
              </>
            ) : (
              <>
                <img className="editProductIcon" src={EditIcon} alt="Edit Icon" />
                <img
                  className="deleteProductIcon"
                  src={DeleteProductIcon}
                  alt="Delete Icon"
                  onClick={handleClickAllowDelete}
                />
              </>
            )}
          </div>
        </td>
      </tr>

      {isOpen && (
        <React.Fragment key="details">
          <CollapseProductDetails
            platformsListedOn={product.platforms}
            condition={product.condition}
          />
        </React.Fragment>
      )}
    </React.Fragment>
  );
};