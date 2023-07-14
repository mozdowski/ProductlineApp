import CancelButton from '../../../atoms/buttons/cancelButton/CancelButton';
import ConfirmChangePersonalDataButton from '../../../atoms/buttons/confirmChangePersonalDataButton/ConfirmAccountDataButton';
import './css/settingsButtonsSection.css';

function ButtonsSection({ onClick, onConfirm }: { onClick?: () => void; onConfirm: () => void }) {
  return (
    <div className="settingsButtonsSection">
      <CancelButton onClick={onClick} />
      <ConfirmChangePersonalDataButton onClick={onConfirm} />
    </div>
  );
}

export default ButtonsSection;
