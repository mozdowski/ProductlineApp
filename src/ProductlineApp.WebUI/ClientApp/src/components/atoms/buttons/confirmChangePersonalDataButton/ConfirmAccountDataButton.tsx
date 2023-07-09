import './css/confirmAccountDataButton.css';

function ConfirmAccountDataButton({ setShowButtons, showButtons }: { setShowButtons?: any, showButtons?: boolean }) {
  return <input type="submit" className="confirmChangePersonalDataButton" value="Zatwierdz" onClick={() => setShowButtons(showButtons)}></ input>;
}

export default ConfirmAccountDataButton;
