import { useState } from 'react';
import ChangePasswordButton from '../../../atoms/buttons/changePasswordButton/ChangePasswordButton';
import FormInput from '../../../atoms/common/formInput/formInput';
import EyeVisible from '../../../../assets/icons/eyeVisible_icon.png';
import EyeInvisible from '../../../../assets/icons/eyeInvisible_icon.png';
import './css/changePassword.css';
import * as Yup from 'yup';
import ButtonsSection from '../../../molecules/settingsSections/buttonsSection/ButtonsSection';
import { ChangePasswordForm } from '../../../../interfaces/settings/changePasswordForm';

const changePasswordSchema = Yup.object().shape({
  newPassword: Yup.string()
    .required('Nowe hasło jest wymagane')
    .min(6, 'Hasło musi mieć co najmniej 6 znaków'),
  oldPassword: Yup.string().required('Podanie starego hasła jest wymagane'),
});

export const ChangePassword = ({
  onPasswordChange,
}: {
  onPasswordChange: (data: ChangePasswordForm) => void;
}) => {
  const [isPasswordVisible, setPasswordVisible] = useState(false);
  const showPassword = () => {
    setPasswordVisible(!isPasswordVisible);
  };
  const [showFields, setShowFields] = useState(true);
  const [errors, setErrors] = useState<Partial<ChangePasswordForm>>({});
  const [changePasswordForm, setPasswordForm] = useState<ChangePasswordForm>({
    newPassword: '',
    oldPassword: '',
  });

  const handlePasswordChange = async () => {
    setShowFields(!showFields);

    const isValid = await validateForm();
    if (!isValid) return;

    onPasswordChange(changePasswordForm);
  };

  const handleFieldsVisibility = () => {
    setShowFields(!showFields);
  };

  const handleChange = (name: string, value: string) => {
    setPasswordForm((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const validateForm = async (): Promise<boolean> => {
    try {
      await changePasswordSchema.validate(changePasswordForm, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<ChangePasswordForm> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof ChangePasswordForm] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  return (
    <div className="changePassword">
      <h1>Zmień Hasło</h1>
      <p className="info">Tutaj możesz zmienić swoje hasło na nowe</p>
      {!showFields && (
        <div className="changePasswordFields">
          <label htmlFor="password" className="changePasswordLabel1">
            Stare hasło
          </label>
          <div className="passwordField">
            <FormInput
              type={!isPasswordVisible ? 'password' : 'text'}
              id="oldPassword"
              name="oldPassword"
              placeholder="Stare hasło"
              className="changePasswordOldPasswordInput"
              value={changePasswordForm.oldPassword}
              onChange={handleChange}
              error={errors.oldPassword}
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
              id="newPassword"
              name="newPassword"
              placeholder="Nowe hasło"
              className="changePasswordNewPasswordInput"
              value={changePasswordForm.newPassword}
              onChange={handleChange}
              error={errors.newPassword}
            />
            <img
              className="resetPasswordImageEye2"
              src={isPasswordVisible ? EyeVisible : EyeInvisible}
              onClick={showPassword}
            />
          </div>
        </div>
      )}
      {!showFields ? (
        <ButtonsSection onClick={handleFieldsVisibility} onConfirm={handlePasswordChange} />
      ) : (
        <ChangePasswordButton onClick={handleFieldsVisibility} />
      )}
    </div>
  );
};
