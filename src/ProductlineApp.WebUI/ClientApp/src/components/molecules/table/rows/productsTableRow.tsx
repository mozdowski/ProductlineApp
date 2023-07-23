import { useCallback, useState } from 'react';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import React from 'react';
import { CollapseProductDetails } from '../bodys/CollapseProductDetails';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import DeleteProductIcon from '../../../../assets/icons/delete_icon.svg';
import { Link } from 'react-router-dom';
import BasicTooltip from '../../../atoms/common/tooltip/basicTooltip';

export const ProductsTableRow = ({
  product,
  onProductDelete,
}: {
  product: ProductsRecord;
  onProductDelete: (productId: string) => void;
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
    <React.Fragment>
      <tr className="ProductsTableRow">
        <td>
          <CollapseTableButton isOpen={isOpen} toggle={toggle} />
        </td>
        <td>{product.sku}</td>
        <td>
          {product.brand}
        </td>
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
          className={`productStatus ${product.isListed && 'productExposed'} ${!product.isListed && 'productNotExposed'
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
                    onClick={() => onProductDelete(product.id)}
                  />
                </div>
              </>
            ) : (
              <>
                <Link to={`/products/edit/${product.id}`} className="editProductLink" id="link">
                  <BasicTooltip title="Edutuj produkt">
                    <img className="editProductIcon" src={EditIcon} alt="Edit Icon" />
                  </BasicTooltip>
                </Link>
                <BasicTooltip title="Usuń produkt">
                  <img
                    className="deleteProductIcon"
                    src={DeleteProductIcon}
                    alt="Delete Icon"
                    onClick={handleClickAllowDelete}
                  />
                </BasicTooltip>
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
