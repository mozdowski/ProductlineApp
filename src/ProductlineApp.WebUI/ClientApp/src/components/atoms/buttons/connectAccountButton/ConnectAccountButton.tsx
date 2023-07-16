import { Link } from 'react-router-dom';
import './css/connectAccountButton.css';

function ConnectAccountButton({ authUrl }: { authUrl?: string }) {
  return (
    <a href={authUrl ? authUrl : ''} className="connectLink" id="link">
      <div className="connectAccountButton">
        <p>Połącz</p>
      </div>
    </a>
  );
}

export default ConnectAccountButton;
