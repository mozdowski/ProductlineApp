import React from 'react';
import './css/OrdersTableHeader.css';

export const OrdersTableHeader = () => {
  return (
    <thead>
      <tr className="OrdersTableHeader">
        <th></th>
        <th>ID Zamówienia</th>
        <th>Data utworzenia</th>
        <th>Wysyłka do dnia</th>
        <th>Zamawiający</th>
        <th>Cena</th>
        <th>Ilość</th>
        <th>Status</th>
        <th>Akcje</th>
      </tr>
    </thead>
  );
};
