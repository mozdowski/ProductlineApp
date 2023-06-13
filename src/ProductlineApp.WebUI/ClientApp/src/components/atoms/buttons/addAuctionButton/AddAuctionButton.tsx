import React from 'react';
import AddIcon from '../../../../assets/icons/add_icon.png';
import { Link } from 'react-router-dom';
import './css/AddAuctionButton.css';

function AddAuctionButton() {
  return (
    <Link to="/auctions/add" className="addAuctionLink" id="link">
      <div className="addAuctionButton">
        <img id="addImage" src={AddIcon} />
        <p>Dodaj Ogłoszenie</p>
      </div>
    </Link>
  );
}

export default AddAuctionButton;
