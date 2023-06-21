import React from 'react';
import OlxIcon from '../../../assets/icons/olx_icon1.svg';
import './css/OlxLink.css';

function OlxLink() {
  return (
    <a href="https://www.olx.pl" target="_blank" rel="noopener noreferrer" className="olxLink">
      <img src={OlxIcon} className="olxIcon"></img>
    </a>
  );
}

export default OlxLink;
