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
import * as Yup from 'yup';
import FormInput from '../components/atoms/common/formInput/formInput';
import { toast } from 'react-toastify';
import { TabTitle } from '../helpers/changePageTitle';

interface SigninForm {
  username: string;
  email: string;
  password: string;
  passwordRep: string;
}

const signinSchema = Yup.object().shape({
  username: Yup.string().required('Nazwa użytkownika jest wymagana'),
  email: Yup.string().email('Nieprawidłowy adres email').required('Email jest wymagany'),
  password: Yup.string()
    .required('Hasło jest wymagane')
    .min(6, 'Hasło musi mieć co najmniej 6 znaków'),
  passwordRep: Yup.string()
    .oneOf([Yup.ref('password')], 'Hasła muszą się zgadzać')
    .required('Powtórzenie hasła jest wymagane'),
});

export default function Signin() {
  TabTitle('productline. Zarejestruj się');

  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const [isSignInButtonEnabled, setIsSignInButtonEnabled] = useState(true);
  const [signinForm, setSigninForm] = useState<SigninForm>({
    username: '',
    email: '',
    password: '',
    passwordRep: '',
  });
  const [errors, setErrors] = useState<Partial<SigninForm>>({});

  const handleChange = (name: string, value: number | string) => {
    setSigninForm((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const validateForm = async (): Promise<boolean> => {
    try {
      await signinSchema.validate(signinForm, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<SigninForm> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof SigninForm] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

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

  const handleRegister = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const isValid: boolean = await validateForm();

    if (!isValid) {
      return;
    }

    const data: RegisterRequest = {
      username: signinForm.username,
      password: signinForm.password,
      email: signinForm.email,
      avatar: image,
    };

    setIsSignInButtonEnabled(false);

    try {
      await toast.promise(register(data), {
        success: 'Zarejestrowano pomyślnie',
        error: 'Błąd rejestracji',
        pending: 'Trwa rejestracja...',
      });
      navigate('/dashboard');
    } catch (error) {
      console.error('Wystąpił błąd podczas rejestracji:', error);
      setIsSignInButtonEnabled(true);
    }
  };

  return (
    <>
      <div className="signinBackground">
        <div className="signin">
          <div className="signinSection">
            <Link to="/login" className="backToLoginPageLink" id="link">
              <img className="backToLoginButton" src={BackButtonImage} />
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
              <FormInput
                type="text"
                id="uname"
                name="username"
                placeholder="Nazwa uzytkownika"
                className="unameInput"
                value={signinForm.username}
                onChange={handleChange}
                error={errors.username}
              />
              <label htmlFor="emial" className="emailLabel">
                Email
              </label>
              <FormInput
                type="email"
                id="email"
                name="email"
                placeholder="Email"
                className="emailInput"
                value={signinForm.email}
                onChange={handleChange}
                error={errors.email}
              />
              <label htmlFor="password" className="passwordLabel">
                Hasło
              </label>
              <div className="passwordField">
                <FormInput
                  type={!isPasswordVisible ? 'password' : 'text'}
                  id="password"
                  name="password"
                  placeholder="Podaj hasło"
                  className="passwordInput"
                  value={signinForm.password}
                  onChange={handleChange}
                  error={errors.password}
                />
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
                <FormInput
                  type={!isPasswordVisible ? 'password' : 'text'}
                  id="repeatPassword"
                  name="passwordRep"
                  placeholder="Podaj hasło"
                  className="repeatPasswordInput"
                  value={signinForm.passwordRep}
                  onChange={handleChange}
                  error={errors.passwordRep}
                />
                <img
                  className="repeatImageEye"
                  src={isPasswordVisible ? EyeVisible : EyeInvisible}
                  onClick={showPassword}
                />
              </div>

              <SigninButton disabled={!isSignInButtonEnabled} />
            </form>
          </div>
        </div>
      </div>
    </>
  );
}
