import CancelButton from '../../../../atoms/buttons/cancelButton/CancelButton';
import ConfrimButton from '../../../../atoms/buttons/confirmButton/ConfirmButton';
import './css/addAuctionButtonsSection.css';

function ButtonsSection({
  confirmDisabled 
}: {
  confirmDisabled: boolean
}) {
  return (
    <>
      <div className="addAuctionButtonsSection">
        <CancelButton pathTo={'/auctions'} />
        <ConfrimButton disabled={confirmDisabled}/>
      </div>
    </>
  );
}

export default ButtonsSection;
