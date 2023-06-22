import { Link, useNavigate } from 'react-router-dom';
import '../pages/css/Signin.css';
import EyeVisible from '../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../assets/icons/eyeInvisible_icon.png';
import UserImage from '../assets/icons/userAvatarImage.jpeg';
import AddPhotoIcon from '../assets/icons/addPhoto_icon.png';
import BackButtonImage from '../assets/icons/back_icon.png';
import React, { useState } from 'react';
import SigninButton from '../components/atoms/buttons/signInButton/SigninButton';
import { useAuth } from '../hooks/auth/useAuth';
import { RegisterRequest } from '../interfaces/auth/registerRequest';

export default function Signin() {
  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [passwordRep, setPasswordRep] = useState('');

  const navigate = useNavigate();
  const { register } = useAuth();

  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };

  const [image, setImage] = useState<File | undefined>(undefined);
  const showImage = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!e.target.files) return;

    setImage(e.target.files[0]);
  };

  const handleRegister = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const data: RegisterRequest = {
      username: username,
      password: password,
      email: email,
      avatar: image,
    };

    register(data)
      .then(() => {
        navigate('/dashboard');
      })
      .catch((error) => {
        console.error('Wystąpił błąd podczas rejestracji:', error);
      });
  };

  return (
    <>
      <div className="signinBackground">
        <div className="signin">
          <div className="signinSection">
            <Link to="/login" className="backToLoginPageLink" id="link">
              <img className="backButton" src={BackButtonImage} />
            </Link>

            <h1>Zarejestruj się</h1>
            <form onSubmit={handleRegister}>
              <div className="avatarField">
                <img
                  className="avatarUploadedImage"
                  src={image === undefined ? UserImage : URL.createObjectURL(image)}
                ></img>
                <div className="file">
                  <input
                    type="file"
                    accept="image/*"
                    id="avatarPhoto"
                    name="avatarPhoto"
                    className="avatarPhotoInput"
                    onChange={showImage}
                  />
                  <img className="addPhotoIcon" src={AddPhotoIcon}></img>
                </div>
              </div>

              <label htmlFor="uname" className="unameLabel">
                Nazwa uzytkownika
              </label>
              <input
                type="text"
                id="uname"
                name="uname"
                placeholder="Nazwa uzytkownika"
                className="unameInput"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              ></input>

              <label htmlFor="emial" className="emailLabel">
                Email
              </label>
              <input
                type="email"
                id="email"
                name="email"
                placeholder="Email"
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

              <label htmlFor="repeatPassword" className="repeatPasswordLabel">
                Powtórz Hasło
              </label>
              <div className="repeatPasswordField">
                <input
                  type={!isPasswordVisible ? 'password' : 'text'}
                  id="repeatPassword"
                  name="repeatPassword"
                  placeholder="Podaj hasło"
                  className="repeatPasswordInput"
                  value={passwordRep}
                  onChange={(e) => setPasswordRep(e.target.value)}
                ></input>
                <img
                  className="repeatImageEye"
                  src={isPasswordVisible ? EyeVisible : EyeInvisible}
                  onClick={showPassword}
                />
              </div>

              <SigninButton />
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
