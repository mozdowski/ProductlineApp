import './css/changePersonalDataButton.css';

function ChangePersonalDataButton({ onClick }: { onClick?: () => void }) {
  return (
    <div className="changePersonalDataButton" onClick={onClick}>
      <p>Zmień swoje dane</p>
    </div>
  );
}

export default ChangePersonalDataButton;
