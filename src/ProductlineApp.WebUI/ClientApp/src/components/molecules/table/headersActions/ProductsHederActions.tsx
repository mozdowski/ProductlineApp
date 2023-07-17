import React from 'react';
import './css/ProductsHederActions.css';
import Searchbar from '../../../atoms/inputs/searchbarInput/Searchbar';
import AddProductButton2 from '../../../atoms/buttons/addProductButtons/AddProductButton2';

export const ProductsHederActions = ({
  searchValue,
  onChange,
}: {
  searchValue: string;
  onChange: (e: any) => void;
}) => {
  return (
    <div className="ProductsTableButtons">
      <Searchbar searchValue={searchValue} onChange={onChange} />
      <AddProductButton2 />
    </div>
  );
};
