import CancelButton from '../../../../atoms/buttons/cancelButton/CancelButton';
import ConfrimButton from '../../../../atoms/buttons/confirmButton/ConfirmButton';
import './css/addProductButtonsSection.css';

function ButtonsSection({
  confirmDisabled
}: {
  confirmDisabled: boolean;
}) {
  return (
    <>
      <div className="addProductButtonsSection">
        <CancelButton pathTo={'/products'} />
        <ConfrimButton disabled={confirmDisabled} />
      </div>
    </>
  );
}

export default ButtonsSection;
