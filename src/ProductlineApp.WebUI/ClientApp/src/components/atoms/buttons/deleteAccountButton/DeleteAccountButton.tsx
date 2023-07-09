import './css/deleteAccountButton.css';

function DeleteAccountButton({ onClick }: { onClick?: () => void }) {
  return (
    <div className="deleteAccountButton" onClick={onClick}>
      <p>Usuń konto</p>
    </div>
  );
}

export default DeleteAccountButton;
