import { Link, useNavigate } from 'react-router-dom';
import LoginButton from '../components/atoms/buttons/logInButton/LoginButton';
import '../pages/css/Login.css';
import EyeVisible from '../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../assets/icons/eyeInvisible_icon.png';
import { useState } from 'react';
import { useAuth } from '../hooks/auth/useAuth';

export default function Login() {
  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const navigate = useNavigate();
  const { login } = useAuth();

  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };

  const handleLogin = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    login(email, password)
      .then(() => {
        navigate('/dashboard');
      })
      .catch((error) => {
        console.log('Wystąpił błąd podczas logowania:', error);
      });
  };

  return (
    <>
      <div className="loginBackground">
        <div className="login">
          <div className="loginSection">
            <h1>Zaloguj się</h1>
            <form onSubmit={handleLogin}>
              <label htmlFor="email" className="emailLabel">
                Email
              </label>
              <input
                type="email"
                id="email"
                name="email"
                placeholder="Podaj email"
                className="emailInput"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              ></input>

              <label htmlFor="password" className="passwordLabel">
                Hasło
              </label>
              <div className="passwordField">
                <input
                  type={!isPasswordVisible ? 'password' : 'text'}
                  id="password"
                  name="password"
                  placeholder="Podaj hasło"
                  className="passwordInput"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                ></input>
                <img
                  className="imageEye"
                  src={isPasswordVisible ? EyeVisible : EyeInvisible}
                  onClick={showPassword}
                />
              </div>

              <Link to="/forgotpassword" className="forgotPasswordLink" id="link">
                <p>Zapomniałeś hasła?</p>
              </Link>

              <LoginButton />

              <h2>
                Jeśli nie masz jeszcze konta{' '}
                <Link to="/signin" className="registerLink" id="link">
                  <p>Zarejestruj się</p>
                </Link>
              </h2>
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
