import './css/SigninButton.css';

function SigninButton({
  disabled
} : {
  disabled: boolean;
}) {
  return <input type="submit" className={`signinButton ${disabled ? 'button-processing' : ''}`} value={'Zarejestruj'} disabled={disabled}/>;
}

export default SigninButton;
