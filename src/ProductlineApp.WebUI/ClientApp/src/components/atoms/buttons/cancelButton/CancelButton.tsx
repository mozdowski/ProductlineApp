import { Link } from 'react-router-dom';
import './css/cancelButton.css';

function CancelButton({
  pathTo,
  close,
  onClick,
}: {
  onClick?: () => void;
  setShowButtons?: () => void;
  showButtons?: boolean;
  pathTo?: any;
  close?: any;
}) {
  return (
    <Link to={pathTo} className="returnToProductsLink" id="link">
      <div className="cancelButton" onClick={onClick}>
        <p>Anuluj</p>
      </div>
    </Link>
  );
}

export default CancelButton;
