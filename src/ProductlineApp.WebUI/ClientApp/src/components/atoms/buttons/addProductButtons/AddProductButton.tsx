import React from 'react';
import AddIcon from '../../../../assets/icons/add_icon.png';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import './css/AddProductButton.css';

function AddProductButton() {
  return (
    <Link to="/products/add" className="addProductLink" id="link">
      <div className="addProductButton">
        <img id="image" src={AddIcon} />
      </div>
    </Link>
  );
}

export default AddProductButton;
