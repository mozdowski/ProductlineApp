import './css/allegroFormPopup.css';
import AllegroLogo from '../../../../../assets/icons/allegroLogo_icon.svg';
import CancelButton from '../../../../atoms/buttons/cancelButton/CancelButton';
import ConfrimButton from '../../../../atoms/buttons/confirmButton/ConfirmButton';
import ProductNameInput from '../../../../atoms/inputs/productNameInput/ProductNameInput';
import SelectProductAllegroIdeas from '../../../../atoms/inputs/selectProductAllegroIdeas/SelectProductAllegroIdeas';
import { AuctionForm } from '../../../../../interfaces/auctions/auctionForm';
import { CloseButton } from 'react-toastify/dist/components';

const AllegroFormPopup = ({
  openAllegroPopup,
  closeAllegroPopup,
  errors,
}: {
  openAllegroPopup: any;
  closeAllegroPopup: any;
  errors: Partial<AuctionForm>;
}) => {
  if (!openAllegroPopup) return null;
  return (
    <div className="overlayAllegroPopup">
      <div
        className="allegroPopup"
        onClick={(e) => {
          e.stopPropagation();
        }}
      >
        <div className="allegroPopupSectionLabel">
          <img src={AllegroLogo} className="allegroBrandIcon" />
          <p>Wypełnij poniższe pola dla wystawianego produktu</p>
        </div>
        <div className="allegroPopupFormInputs">
          <form>
            <div className="firstLineAllegroAuctionInputs">
              <ProductNameInput
                value={''}
                onChange={function (name: string, value: string): void {
                  throw new Error('Function not implemented.');
                }}
                error={errors}
                disabled={false}
              />
              <SelectProductAllegroIdeas />
            </div>
            <div className="secondLineAllegroAuctionInputs"></div>
            <div className="thirdLineAllegroAuctionInputs"></div>
            <div className="fourthLineAllegroAuctionInputs"></div>
          </form>
          <div className="addauctionAllegroButtons">
            <CancelButton pathTo={''} close={closeAllegroPopup} />
            <ConfrimButton />
          </div>
        </div>
      </div>
    </div>
  );
};

export default AllegroFormPopup;
