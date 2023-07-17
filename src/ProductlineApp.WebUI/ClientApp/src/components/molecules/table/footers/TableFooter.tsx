import React from 'react';
import './css/TableFooter.css';

export const TableFooter = () => {
  return (
    <div className="paginationTable">
      <ul className="pagination">
        <li>
          <div className="paginationNextButton activePage">
            <p>1</p>
          </div>
        </li>
        <li>
          <div className="paginationNextButton">
            <p>2</p>
          </div>
        </li>
        <li>
          <div className="paginationNextButton">
            <p>3</p>
          </div>
        </li>
      </ul>
    </div>
  );
};
