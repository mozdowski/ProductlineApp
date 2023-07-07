import './backButton.css';

function BackButton({ onClick }: { onClick: any }) {
  return (
    <a className="backButton" onClick={onClick}>
      <p>Wróć</p>
    </a>
  );
}

export default BackButton;
