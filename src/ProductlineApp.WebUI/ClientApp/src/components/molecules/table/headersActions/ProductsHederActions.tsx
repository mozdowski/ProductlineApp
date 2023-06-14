import React from 'react';
import './css/ProductsHederActions.css';
import Searchbar from '../../../atoms/inputs/searchbarInput/Searchbar';
import AddProductButton2 from '../../../atoms/buttons/addProductButtons/AddProductButton2';

export const ProductsHederActions = () => {
  return (
    <div className="ProductsTableButtons">
      <Searchbar />
      <AddProductButton2 />
    </div>
  );
};
