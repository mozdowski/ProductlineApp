import { useState } from 'react';
import ChangePersonalDataButton from '../../../atoms/buttons/changePersonalDataButton/ChangePersonalDataButton';
import './css/changePersonalDataSection.css';
import ButtonsSection from '../../../molecules/settingsSections/buttonsSection/ButtonsSection';
import FormInput from '../../../atoms/common/formInput/formInput';
import * as Yup from 'yup';

const changePersonalDetailsSchema = Yup.object().shape({
  username: Yup.string().required('Nazwa użytkownika jest wymagana'),
  email: Yup.string().email('Nieprawidłowy adres email').required('Email jest wymagany'),
});

function ChangePersonalDataSection() {
  const [disableEdit, setDisableEdit] = useState(true);
  const [errors, setErrors] = useState<Partial<ChangePersonalDetailsForm>>({});

  const handleClickEditFields = () => {
    setDisableEdit(!disableEdit);
  };

  return (
    <>
      <form>
        <div className="changePesonalDataSection">
          <div className="userNameField">
            <label htmlFor="uname" className="unameLabel">
              Nazwa uzytkownika
            </label>
            <FormInput
              type="text"
              id="uname"
              name="uname"
              placeholder="Nazwa uzytkownika"
              className="changeUsernameInput"
              disabled={disableEdit}
              value={''}
              onChange={() => {}}
              error={errors.username}
            />
          </div>
          <div className="emailInputField">
            <label htmlFor="email" className="emailLabel">
              Email
            </label>
            <FormInput
              type="email"
              id="email"
              name="email"
              placeholder="Email"
              className="changeEmailInput"
              disabled={disableEdit}
              value={''}
              onChange={() => {}}
              error={errors.email}
            />
          </div>
        </div>
      </form>
      {!disableEdit ? (
        <ButtonsSection onClick={handleClickEditFields} />
      ) : (
        <ChangePersonalDataButton onClick={handleClickEditFields} />
      )}
    </>
  );
}

export default ChangePersonalDataSection;
