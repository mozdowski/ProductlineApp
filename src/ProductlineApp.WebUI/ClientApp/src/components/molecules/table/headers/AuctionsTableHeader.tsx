import React from 'react';
import './css/AuctionsTableHeader.css';

export const AuctionsTableHeader = () => {
  return (
    <thead>
      <tr className="AuctionsTableHeader">
        <th></th>
        <th>ID Aukcji</th>
        <th>SKU</th>
        <th>Marka</th>
        <th>Nazwa</th>
        <th>Kategoria</th>
        <th>Cena</th>
        <th>Ilość</th>
        <th>Akcje</th>
      </tr>
    </thead>
  );
};
