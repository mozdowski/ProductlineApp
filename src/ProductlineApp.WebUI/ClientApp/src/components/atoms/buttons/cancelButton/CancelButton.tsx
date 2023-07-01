import { Link } from 'react-router-dom';
import './css/cancelButton.css';

function CancelButton({ pathTo, close }: { pathTo?: any, close?: any }) {
  return (
    <Link to={pathTo} className="returnToProductsLink" id="link">
      <div className="cancelButton" onClick={close}>
        <p>Anuluj</p>
      </div>
    </Link>
  );
}

export default CancelButton;
