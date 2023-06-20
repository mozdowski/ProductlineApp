import { Link } from "react-router-dom";
import './css/cancelButton.css';

function CancelButton() {
    return (
        <Link to="/products" className="returnToProductsLink" id="link">
            <div className="cancelButton">
                <p>Anuluj</p>
            </div>
        </Link>
    );
}

export default CancelButton