import React, { useCallback, useState } from 'react';
import { CollapseTableButton } from '../../../atoms/buttons/collapseTableButton/CollapseTableButton';
import { CollapseProductDetails } from './CollapseProductDetails';
import EditIcon from '../../../../assets/icons/edit_icon.svg';
import DeleteProductIcon from '../../../../assets/icons/delete_icon.svg';
import './css/ProductsTableBody.css';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';
import { ProductsTableRow } from './rows/productsTableRow';

export const ProductsTableBody = ({ productRecords }: { productRecords: ProductsRecord[] }) => {
  return (
    <tbody>
      {productRecords.map((product, key) => (
        <ProductsTableRow key={key} product={product} />
      ))}
    </tbody>
  );
};
