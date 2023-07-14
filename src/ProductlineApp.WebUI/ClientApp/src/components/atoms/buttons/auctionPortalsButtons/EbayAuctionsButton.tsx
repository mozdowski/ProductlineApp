import EbayIcon from '../../../../assets/icons/ebay_icon.svg';
import './css/ebayAuctionsButton.css';
import { PlatformEnum } from '../../../../enums/platform.enum';

function EbayAuctionsButton({
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
      className={selectedAuctionPortal === PlatformEnum.EBAY ? 'ebayButton selected' : 'ebayButton'}
      onClick={() => handleClickTypeAuctionPortalButton(PlatformEnum.EBAY)}
    >
      <img className="ebayIcon" src={EbayIcon} />
    </div>
  );
}

export default EbayAuctionsButton;
