import React, { useState } from 'react';
import SearchIcon from '../../../../assets/icons/search_icon.svg';
import './css/Searchbar.css';

function Searchbar({ searchValue, onChange }: { searchValue: string, onChange: (e: any) => void }) {

  return (
    <div className="searchabar">
      <img className="searchImage" src={SearchIcon}></img>
      <input type="text" placeholder="Szukaj" className="searchProductInput"
        value={searchValue}
        onChange={onChange}>
      </input>
    </div >
  );
}

export default Searchbar;
