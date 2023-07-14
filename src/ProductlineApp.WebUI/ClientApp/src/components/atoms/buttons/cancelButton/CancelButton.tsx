import { Link } from 'react-router-dom';
import './css/cancelButton.css';

function CancelButton({ pathTo, onClick }: { onClick?: () => void; pathTo?: any }) {
  return (
    <Link to={pathTo} className="returnToProductsLink" id="link" onClick={onClick}>
      <div className="cancelButton">
        <p>Anuluj</p>
      </div>
    </Link>
  );
}

export default CancelButton;
