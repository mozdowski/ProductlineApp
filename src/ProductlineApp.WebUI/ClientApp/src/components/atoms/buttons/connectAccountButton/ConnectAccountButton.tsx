import { Link } from 'react-router-dom';
import './css/connectAccountButton.css';

function ConnectAccountButton() {
  return (
    <Link to="" className="connectLink" id="link">
      <div className="connectAccountButton">
        <p>Połącz</p>
      </div>
    </Link>
  )
}

export default ConnectAccountButton;
