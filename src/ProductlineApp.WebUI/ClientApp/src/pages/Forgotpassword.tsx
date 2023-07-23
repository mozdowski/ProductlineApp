import { Link } from 'react-router-dom';
import '../pages/css/Forgotpassword.css';
import BackButtonImage from '../assets/icons/back_icon.png';
import ResetPasswordButton from '../components/atoms/buttons/resetPasswordButton/ResetPasswordButton';

export default function Forgotpassword() {
  return (
    <>
      <div className="forgotPasswordBackground">
        <div className="forgotPassword">
          <div className="forgotPasswordSection">
            <Link to="/login" className="backToLoginPageLink" id="link">
              <img className="backToLoginButton" src={BackButtonImage} />
            </Link>

            <h1>Reset hasła</h1>
            <form>
              <label htmlFor="emial" className="emailLabel">
                Email
              </label>
              <input
                type="email"
                id="email"
                name="email"
                placeholder="Podaj email"
                className="emailInput"
              ></input>
              <ResetPasswordButton />
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
