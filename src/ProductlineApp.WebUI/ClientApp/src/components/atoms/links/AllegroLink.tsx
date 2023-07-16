import React from 'react';
import './css/allegroLink.css';

function AllegroLink() {
  return (
    <a href="https://www.allegro.pl" target="_blank" rel="noopener noreferrer" className="allegroLink">
      <div className="allegroLinkProductButton">
        <span className="allegroLinkProductIcon allegroProductLinkIcon" />
      </div>
    </a>
  );
}

export default AllegroLink;
