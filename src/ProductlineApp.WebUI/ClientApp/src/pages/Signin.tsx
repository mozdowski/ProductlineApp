import { Link } from 'react-router-dom';
import '../pages/css/Signin.css';
import EyeVisible from '../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../assets/icons/eyeInvisible_icon.png';
import UserImage from '../assets/icons/userAvatarImage.jpeg';
import AddPhotoIcon from '../assets/icons/addPhoto_icon.png';
import BackButtonImage from '../assets/icons/back_icon.png';
import React, { useState } from 'react';
import SigninButton from '../components/atoms/buttons/signInButton/SigninButton';

export default function Signin() {
  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };

  const [image, setImage] = useState<File | null>(null);
  const showImage = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!e.target.files) return;

    setImage(e.target.files[0]);
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
            <form>
              <div className="avatarField">
                <img
                  className="avatarUploadedImage"
                  src={image === null ? UserImage : URL.createObjectURL(image)}
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
