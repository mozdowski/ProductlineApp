import { Link, useNavigate } from 'react-router-dom';
import LoginButton from '../components/atoms/buttons/logInButton/LoginButton';
import '../pages/css/Login.css';
import EyeVisible from '../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../assets/icons/eyeInvisible_icon.png';
import { useState } from 'react';
import { useAuth } from '../hooks/auth/useAuth';
import * as Yup from 'yup';
import FormInput from '../components/atoms/common/formInput/formInput';
import { toast } from 'react-toastify';

const loginSchema = Yup.object().shape({
  email: Yup.string().email('Podaj poprawny adres email').required('Email jest wymagany'),
  password: Yup.string().required('Hasło jest wymagane'),
});

interface LoginForm {
  email: string;
  password: string;
}

export default function Login() {
  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const [loginForm, setLoginForm] = useState<LoginForm>({
    email: '',
    password: '',
  });
  const [errors, setErrors] = useState<Partial<LoginForm>>({});

  const navigate = useNavigate();
  const { login } = useAuth();

  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };

  const handleChange = (name: string, value: number | string) => {
    setLoginForm((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const validateForm = async (): Promise<boolean> => {
    try {
      await loginSchema.validate(loginForm, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<LoginForm> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof LoginForm] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  const handleLogin = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const isValid: boolean = await validateForm();

    if (!isValid) {
      return;
    }

    login(loginForm.email, loginForm.password)
      .then(() => {
        navigate('/dashboard');
        toast.success('Zalogowano pomyślnie', {
          position: toast.POSITION.TOP_RIGHT,
          autoClose: 1000,
        });
      })
      .catch((error) => {
        toast.error('Błąd logowania', {
          position: toast.POSITION.TOP_RIGHT,
        });
        console.error('Wystąpił błąd podczas logowania:', error);
      });
  };

  return (
    <>
      <div className="loginBackground">
        <div className="login">
          <div className="loginSection">
            <h1>Zaloguj się</h1>
            <form onSubmit={handleLogin} noValidate>
              <label htmlFor="email" className="emailLabel">
                Email
              </label>
              <FormInput
                type="email"
                id="email"
                name="email"
                placeholder="Podaj email"
                className="emailInput"
                value={loginForm.email}
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
                  value={loginForm.password}
                  onChange={handleChange}
                  error={errors.password}
                />
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
