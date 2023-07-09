import CancelButton from '../../../atoms/buttons/cancelButton/CancelButton';
import ConfirmChangePersonalDataButton from '../../../atoms/buttons/confirmChangePersonalDataButton/ConfirmAccountDataButton';
import './css/settingsButtonsSection.css';

function ButtonsSection({ setShowButtons, showButtons }: { setShowButtons?: any, showButtons?: boolean }) {
  return (
    <div className="settingsButtonsSection">
      <CancelButton setShowButtons={setShowButtons} showButtons={showButtons} />
      <ConfirmChangePersonalDataButton setShowButtons={setShowButtons} showButtons={showButtons} />
    </div>
  );
}

export default ButtonsSection;
