import AllegroIcon from '../../../../assets/icons/allegro_a_logo_icon.svg';
import './css/allegroAuctionsButton.css';
import { PlatformEnum } from '../../../../enums/platform.enum';

function AllegroAuctionsButton({
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
        selectedAuctionPortal === PlatformEnum.ALLEGRO ? 'allegroButton selected' : 'allegroButton'
      }
      onClick={() => handleClickTypeAuctionPortalButton(PlatformEnum.ALLEGRO)}
    >
      <span className="iconAuctionsAllegro allegroAuctionsIcon" />
    </div>
  );
}

export default AllegroAuctionsButton;
