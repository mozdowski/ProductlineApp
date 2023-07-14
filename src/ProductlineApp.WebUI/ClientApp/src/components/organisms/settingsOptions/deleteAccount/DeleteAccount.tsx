import DeleteAccountButton from '../../../atoms/buttons/deleteAccountButton/DeleteAccountButton';
import FormInput from '../../../atoms/common/formInput/formInput';
import EyeVisible from '../../../../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../../../../assets/icons/eyeInvisible_icon.png';
import './css/deleteAccount.css';
import { useState } from 'react';
import * as Yup from 'yup';
import ButtonsSection from '../../../molecules/settingsSections/buttonsSection/ButtonsSection';
import { DeleteAccountForm } from '../../../../interfaces/settings/deleteAccountForm';

const deleteAcountPasswordSchema = Yup.object().shape({
  password: Yup.string().required('Hasło jest wymagane'),
  checkPassword: Yup.string().required('Podaj poprawne hasło'),
});

export const DeleteAccount = () => {
  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const [showField, setShowField] = useState(true);
  const [errors, setErrors] = useState<Partial<DeleteAccountForm>>({});

  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };

  const handleClickShowFields = () => {
    setShowField(!showField);
  };

  const handleConfirm = () => {};

  const handleChange = (name: string, value: number | string) => {};

  return (
    <div className="deleteAccount">
      <h1>Usuń Konto</h1>
      <p className="info">Tutaj możesz usunąć konto</p>
      {!showField && (
        <div className="deleteAccountField">
          <div className="passwordField">
            <FormInput
              type={!isPasswordVisible ? 'password' : 'text'}
              id="password"
              name="password"
              placeholder="Twoje hasło"
              className="deleteAccountPasswordInput"
              value={''}
              onChange={handleChange}
              error={errors.password}
            />
            <img
              className="deleteAccountImageEye"
              src={isPasswordVisible ? EyeVisible : EyeInvisible}
              onClick={showPassword}
            />
          </div>
        </div>
      )}
      {!showField ? (
        <ButtonsSection onClick={handleClickShowFields} onConfirm={handleConfirm} />
      ) : (
        <DeleteAccountButton onClick={handleClickShowFields} />
      )}
    </div>
  );
};
