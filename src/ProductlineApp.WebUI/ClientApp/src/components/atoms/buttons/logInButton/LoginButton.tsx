import './css/LoginButton.css';

function LoginButton({
  disabled
}: {
  disabled: boolean
}) {
  return <input type="submit" className={disabled ? 'loginButton button-processing' : 'loginButton'} value={'Zaloguj'} disabled={disabled} />;
}

export default LoginButton;
