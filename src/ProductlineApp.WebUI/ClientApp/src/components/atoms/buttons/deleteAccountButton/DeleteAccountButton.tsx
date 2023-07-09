import './css/deleteAccountButton.css';

function DeleteAccountButton({ setShowField, showField }: { setShowField: any, showField: boolean }) {
  return (
    <div className="deleteAccountButton" onClick={() => setShowField(!showField)}>
      <p>Usuń konto</p>
    </div>
  );
}

export default DeleteAccountButton;
