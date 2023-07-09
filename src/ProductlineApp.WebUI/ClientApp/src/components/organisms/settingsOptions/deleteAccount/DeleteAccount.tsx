import DeleteAccountButton from '../../../atoms/buttons/deleteAccountButton/DeleteAccountButton';
import FormInput from '../../../atoms/common/formInput/formInput';
import EyeVisible from '../../../../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../../../../assets/icons/eyeInvisible_icon.png';
import './css/deleteAccount.css';
import { useState } from 'react';
import ConfrimButton from '../../../atoms/buttons/confirmButton/ConfirmButton';
import CancelButton from '../../../atoms/buttons/cancelButton/CancelButton';
import ButtonsSection from '../../../molecules/settingsSections/buttonsSection/ButtonsSection';

export const DeleteAccount = () => {

  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const [showField, setShowField] = useState(true);
  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };

  const handleChange = (name: string, value: number | string) => { };

  return (
    <div className="deleteAccount">
      <h1>Usuń Konto</h1>
      <p className="info">Tutaj możesz usunąć konto</p>
      {!showField &&
        <div className="deleteAccountField">
          <div className="passwordField">
            <FormInput
              type={!isPasswordVisible ? 'password' : 'text'}
              id="password"
              name="password"
              placeholder="Twoje hasło"
              className="deleteAccountPasswordInput"
              value={""}
              onChange={handleChange}
              error={""}
            />
            <img
              className="deleteAccountImageEye"
              src={isPasswordVisible ? EyeVisible : EyeInvisible}
              onClick={showPassword}
            />
          </div>
        </div>
      }
      {!showField ? <ButtonsSection setShowButtons={setShowField} showButtons={!showField} /> : <DeleteAccountButton setShowField={setShowField} showField={showField} />}

    </div>
  );
};
