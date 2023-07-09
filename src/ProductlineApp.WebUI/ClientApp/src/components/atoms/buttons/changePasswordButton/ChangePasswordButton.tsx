import './css/changePasswordButton.css';

function ChangePasswordButton({ onClick }: { onClick?: () => void }) {
  return (
    <div className="changePasswordButton" onClick={onClick}>
      <p>Zmień hasło</p>
    </div>
  );
}

export default ChangePasswordButton;
