import OlxIcon from '../../../../assets/icons/olx_icon1.svg';
import './css/olxAuctionsButton.css';
import { PlatformEnum } from '../../../../enums/platform.enum';

function OlxAuctionsButton({
  selectedAuctionPortal,
  handleClickTypeAuctionPortalButton,
  id,
}: {
  selectedAuctionPortal: PlatformEnum;
  handleClickTypeAuctionPortalButton: any;
  id: PlatformEnum;
}) {
  return (
    <div
      id={id + ''}
      className={selectedAuctionPortal === PlatformEnum.OLX ? 'olxButton selected' : 'olxButton'}
      onClick={() => handleClickTypeAuctionPortalButton(PlatformEnum.OLX)}
    >
      <img className="olxIcon" src={OlxIcon} />
    </div>
  );
}

export default OlxAuctionsButton;
