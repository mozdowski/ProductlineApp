import CancelButton from '../../../../atoms/buttons/cancelButton/CancelButton';
import ConfrimButton from '../../../../atoms/buttons/confirmButton/ConfirmButton';
import './css/addProductButtonsSection.css';

function ButtonsSection() {
  return (
    <>
      <div className="addProductButtonsSection">
        <CancelButton pathTo={'/products'} />
        <ConfrimButton />
      </div>
    </>
  );
}

export default ButtonsSection;
