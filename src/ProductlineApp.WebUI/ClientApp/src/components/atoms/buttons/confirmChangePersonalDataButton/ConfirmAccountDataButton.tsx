import './css/confirmAccountDataButton.css';

function ConfirmAccountDataButton({ onClick }: { onClick?: () => void }) {
  return (
    <input
      type="submit"
      className="confirmChangePersonalDataButton"
      value="Zatwierdz"
      onClick={onClick}
    ></input>
  );
}

export default ConfirmAccountDataButton;
