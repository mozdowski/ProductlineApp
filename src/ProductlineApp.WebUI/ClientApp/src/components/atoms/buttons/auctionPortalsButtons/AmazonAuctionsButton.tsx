import AmazonIcon from '../../../../assets/icons/amazon_icon1.svg';
import './css/amazonAuctionsButton.css';
import { PlatformEnum } from '../../../../enums/platform.enum';

function AmazonAuctionsButton({
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
      className={
        selectedAuctionPortal === PlatformEnum.AMAZON ? 'amazonButton selected' : 'amazonButton'
      }
      onClick={() => handleClickTypeAuctionPortalButton(PlatformEnum.AMAZON)}
    >
      <img className="amazonIcon" src={AmazonIcon} />
    </div>
  );
}

export default AmazonAuctionsButton;
