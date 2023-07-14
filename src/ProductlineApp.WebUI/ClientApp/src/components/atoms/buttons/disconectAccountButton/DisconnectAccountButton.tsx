import './css/disconnectAccountButton.css';

function DisconnectAccountButton({
  onDisconnect,
  id,
}: {
  onDisconnect: (platformId: string) => void;
  id: string;
}) {
  return (
    <a className="disconnectLink" onClick={() => onDisconnect(id)} id={id}>
      <div className="disconnectAccountButton">
        <p>Odłącz</p>
      </div>
    </a>
  );
}

export default DisconnectAccountButton;
