import React from 'react';
import './css/ProductsTableHeader.css';

export const ProductsTableHeader = () => {
  return (
    <thead>
      <tr className="ProductsTableHeader">
        <th></th>
        <th>SKU</th>
        <th>Marka</th>
        <th>Nazwa</th>
        <th>Kategoria</th>
        <th>Cena</th>
        <th>Ilość</th>
        <th>Status</th>
        <th>Akcje</th>
      </tr>
    </thead>
  );
};
