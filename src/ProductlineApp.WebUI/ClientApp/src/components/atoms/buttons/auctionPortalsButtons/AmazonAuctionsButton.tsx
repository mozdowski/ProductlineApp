import AllegroIcon from '../../../../assets/icons/allegro_a_logo_icon.svg';
import './css/amazonAuctionsButton.css';
import { PlatformEnum } from '../../../../enums/platform.enum';

function AmazonAuctionsButton({
  selectedAuctionPortal,
  handleClickTypeAuctionPortalButton,
  id,
}: {
  selectedAuctionPortal?: PlatformEnum;
  handleClickTypeAuctionPortalButton: any;
  id: PlatformEnum;
}) {
  return (
    <div
      id={id + ''}
      className={
        selectedAuctionPortal === PlatformEnum.ALLEGRO ? 'amazonButton selected' : 'amazonButton'
      }
      onClick={() => handleClickTypeAuctionPortalButton(PlatformEnum.ALLEGRO)}
    >
      <img className="amazonIcon" src={AllegroIcon} />
    </div>
  );
}

export default AmazonAuctionsButton;
