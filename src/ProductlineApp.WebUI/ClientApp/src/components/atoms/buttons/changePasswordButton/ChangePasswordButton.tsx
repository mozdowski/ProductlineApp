import './css/changePasswordButton.css';

function ChangePasswordButton({ setShowField, showField }: { setShowField: any, showField: boolean }) {
  return (
    <div className="changePasswordButton" onClick={() => setShowField(!showField)}>
      <p>Zmień hasło</p>
    </div>
  );
}

export default ChangePasswordButton;
