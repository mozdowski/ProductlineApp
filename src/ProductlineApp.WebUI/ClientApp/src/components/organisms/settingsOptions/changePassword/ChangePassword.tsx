import { useState } from 'react';
import ChangePasswordButton from '../../../atoms/buttons/changePasswordButton/ChangePasswordButton';
import FormInput from '../../../atoms/common/formInput/formInput';
import EyeVisible from '../../../../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../../../../assets/icons/eyeInvisible_icon.png';
import './css/changePassword.css';
import ButtonsSection from '../../../molecules/settingsSections/buttonsSection/ButtonsSection';

export const ChangePassword = () => {

  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };
  const [showFields, setShowFields] = useState(true);
  const [showPasswordFields, setShowPasswordFields] = useState(false);

  const handleChange = (name: string, value: number | string) => { };

  return (
    <div className="changePassword">
      <h1>Zmień Hasło</h1>
      <p className="info">Tutaj możesz zmienić swoje hasło na nowe</p>
      {!showFields &&
        <div className="changePasswordFields">
          <label htmlFor="password" className="changePasswordLabel1">
            Stare hasło
          </label>
          <div className="passwordField">
            <FormInput
              type={!isPasswordVisible ? 'password' : 'text'}
              id="password"
              name="password"
              placeholder="Stare hasło"
              className="changePasswordOldPasswordInput"
              value={""}
              onChange={handleChange}
              error={""}
            />
            <img
              className="resetPasswordImageEye1"
              src={isPasswordVisible ? EyeVisible : EyeInvisible}
              onClick={showPassword}
            />
          </div>
          <label htmlFor="newPassword" className="changePasswordLabel2">
            Nowe hasło
          </label>
          <div className="passwordField">
            <FormInput
              type={!isPasswordVisible ? 'password' : 'text'}
              id="password"
              name="password"
              placeholder="Nowe hasło"
              className="changePasswordNewPasswordInput"
              value={""}
              onChange={handleChange}
              error={""}
            />
            <img
              className="resetPasswordImageEye2"
              src={isPasswordVisible ? EyeVisible : EyeInvisible}
              onClick={showPassword}
            />
          </div>
        </div>
      }
      {!showFields ? <ButtonsSection setShowButtons={setShowFields} showButtons={!showFields} /> : <ChangePasswordButton setShowField={setShowFields} showField={showFields} />}
    </div >
  );
};

