import React, { useState } from 'react';
import SearchIcon from '../../../../assets/icons/search_icon.svg';
import './css/Searchbar.css';

function Searchbar() {
  return (
    <div className="searchabar">
      <img className="searchImage" src={SearchIcon}></img>
      <input type="text" placeholder="Szukaj" className="searchProductInput"></input>
    </div>
  );
}

export default Searchbar;
