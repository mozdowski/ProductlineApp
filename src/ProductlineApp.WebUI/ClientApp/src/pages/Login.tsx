import { Link } from 'react-router-dom';
import LoginButton from '../components/atoms/buttons/logInButton/LoginButton';
import '../pages/css/Login.css';
import EyeVisible from "../assets/icons/eyeVisible_icon.png";
import EyeInvisible from "../assets/icons/eyeInvisible_icon.png";
import { useState } from 'react';

export default function Login() {

    const [isPasswordVisible, setPasswordVisible] = useState(false);

    const showPassword = () => {
        setPasswordVisible(!isPasswordVisible);
    };

    return (
        <>
            <div className='loginBackground'>
                <div className='login'>
                    <div className='loginSection'>
                        <h1>Zaloguj się</h1>
                        <form>

                            <label htmlFor="emial" className="emailLabel">Email</label>
                            <input type="email" id="email" name="email" placeholder="Podaj email" className="emailInput"></input>

                            <label htmlFor="password" className="passwordLabel">Hasło</label>
                            <div className="passwordField">
                                <input type={!isPasswordVisible ? "password" : "text"} id="password" name="password" placeholder="Podaj hasło" className="passwordInput"></input>
                                <img className="imageEye" src={isPasswordVisible ? EyeVisible : EyeInvisible} onClick={showPassword} />
                            </div>

                            <Link to="/forgotpassword" className="forgotPasswordLink" id="link">
                                <p>Zapomniałeś hasła?</p>
                            </Link>

                            <LoginButton />

                            <h2>Jeśli nie masz jeszcze konta <Link to="/signin" className="registerLink" id="link"><p>Zarejestruj się</p></Link></h2>

                        </form>
                    </div>
                </div>
            </div>
        </>
    );
}