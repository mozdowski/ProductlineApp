import CancelButton from '../../../atoms/buttons/cancelButton/CancelButton';
import ConfirmChangePersonalDataButton from '../../../atoms/buttons/confirmChangePersonalDataButton/ConfirmAccountDataButton';
import './css/settingsButtonsSection.css';

function ButtonsSection({ onClick }: { onClick?: () => void }) {
  return (
    <div className="settingsButtonsSection">
      <CancelButton onClick={onClick} />
      <ConfirmChangePersonalDataButton onClick={onClick} />
    </div>
  );
}

export default ButtonsSection;
