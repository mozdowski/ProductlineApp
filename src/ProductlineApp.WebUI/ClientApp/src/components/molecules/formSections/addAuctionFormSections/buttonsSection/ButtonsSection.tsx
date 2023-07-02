import CancelButton from '../../../../atoms/buttons/cancelButton/CancelButton';
import ConfrimButton from '../../../../atoms/buttons/confirmButton/ConfirmButton';
import './css/addAuctionButtonsSection.css';

function ButtonsSection() {
  return (
    <>
      <div className="addAuctionButtonsSection">
        <CancelButton pathTo={'/auctions'} />
        <ConfrimButton />
      </div>
    </>
  );
}

export default ButtonsSection;
