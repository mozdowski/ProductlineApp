import React from 'react';
import AddIcon from '../../../../assets/icons/add_icon.png';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import './css/AddProductButton.css';
import BasicTooltip from '../../common/tooltip/basicTooltip';

function AddProductButton() {
  return (
    <BasicTooltip title="Dodaj produkt" placement="bottom">
      <Link to="/products/add" className="addProductLink" id="link">
        <div className="addProductButton">
          <img id="image" src={AddIcon} />
        </div>
      </Link>
    </BasicTooltip>
  );
}

export default AddProductButton;
