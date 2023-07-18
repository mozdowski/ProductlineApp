import CancelButton from '../../atoms/buttons/cancelButton/CancelButton';
import OkButton from '../../atoms/buttons/okButton/okButton';
import './confirmationPopup.css';

export interface ConfirmationPopupProps {
  text: string;
  onConfirm: () => void;
  onCancel: () => void;
}

const ConfirmationPopup: React.FC<ConfirmationPopupProps> = ({ text, onCancel, onConfirm }) => {
  return (
    <div className="overlayConfirmationPopup">
      <div
        className="confirmationPopup"
        onClick={(e) => {
          e.stopPropagation();
        }}
      >
        <div className="confirmationText">
          <p>{text}</p>
        </div>
        <div className="confirmationButtons">
          <CancelButton onClick={onCancel} />
          <OkButton onClick={onConfirm} />
        </div>
      </div>
    </div>
  );
};
export default ConfirmationPopup;
