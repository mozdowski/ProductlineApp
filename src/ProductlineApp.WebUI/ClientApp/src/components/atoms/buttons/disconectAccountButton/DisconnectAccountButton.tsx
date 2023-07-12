import './css/disconnectAccountButton.css';

function DisconnectAccountButton({
  onDisconnect,
  name,
}: {
  onDisconnect: (platformName: string) => void;
  name: string;
}) {
  return (
    <a className="disconnectLink" onClick={() => onDisconnect(name)} id={name}>
      <div className='disconnectAccountButton'>
        <p>Odłącz</p>
      </div>
    </a>
  );
}

export default DisconnectAccountButton;
