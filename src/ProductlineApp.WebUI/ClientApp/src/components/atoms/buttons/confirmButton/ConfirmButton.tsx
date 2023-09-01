import './css/confirmButton.css';

function ConfrimButton({
  disabled
}: {
  disabled: boolean
}) {
  return <input type="submit" className={`confrimButton ${disabled ? 'button-processing' : ''}`} value="Zatwierdz" disabled={disabled}></input>;
}

export default ConfrimButton;
