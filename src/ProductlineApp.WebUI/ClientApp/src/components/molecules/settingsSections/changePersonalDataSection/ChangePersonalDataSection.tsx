import { useState } from 'react';
import ChangePersonalDataButton from '../../../atoms/buttons/changePersonalDataButton/ChangePersonalDataButton';
import EmailInput from '../../../atoms/inputs/emailInput/EmailInput';
import UsernameInput from '../../../atoms/inputs/usernameInput/UsernameInput';
import './css/changePersonalDataSection.css';
import ConfirmChangePersonalDataButton from '../../../atoms/buttons/confirmChangePersonalDataButton/ConfirmAccountDataButton';
import CancelButton from '../../../atoms/buttons/cancelButton/CancelButton';
import ButtonsSection from '../../../molecules/settingsSections/buttonsSection/ButtonsSection';

function ChangePersonalDataSection() {

  const [disableEdit, setDisableEdit] = useState(true)

  return (
    <>
      <form>
        <div className="changePesonalDataSection">
          <div className="userNameField">
            <label htmlFor="uname" className="unameLabel">Nazwa uzytkownika</label>
            <input
              type="text"
              id="uname"
              name="uname"
              placeholder="Nazwa uzytkownika"
              className="changeUsernameInput"
              disabled={disableEdit}
            ></input>
          </div>
          <div className="emailInputField">
            <label htmlFor="email" className="emailLabel">Email</label>
            <input
              type="email"
              id="email"
              name="email"
              placeholder="Email"
              className="changeEmailInput"
              disabled={disableEdit}
            ></input>
          </div>
        </div>
      </form>
      {!disableEdit ? <ButtonsSection setShowButtons={setDisableEdit} showButtons={!disableEdit} /> : <ChangePersonalDataButton setDisableEdit={setDisableEdit} disableEdit={disableEdit} />}
    </>
  );
}

export default ChangePersonalDataSection;
