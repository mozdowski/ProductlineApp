import './css/AuctionsTemplate.css';
import { AuctionsRecord } from '../../interfaces/auctions/AuctionsPageInteface';
import AuctionsPageHeader from '../organisms/pageHeaders/AuctionsPageHeader';
import AuctionsTable from '../organisms/tables/AuctionsTable';
import AmazonAuctionsButton from '../atoms/buttons/auctionPortalsButtons/AmazonAuctionsButton';
import EbayAuctionsButton from '../atoms/buttons/auctionPortalsButtons/EbayAuctionsButton';
import OlxAuctionsButton from '../atoms/buttons/auctionPortalsButtons/OlxAuctionsButton';
import { PlatformEnum } from '../../enums/platform.enum';

export default function AuctionsTemplate({
  auctionRecords,
  selectedAuctionPortal,
  handleClickTypeAuctionPortalButton,
  handleClickTypeAuctionsButton,
  isSelectedTypeAuctions,
  onEditAuction,
  onWithdrawAuction,
}: {
  auctionRecords: AuctionsRecord[];
  selectedAuctionPortal: PlatformEnum;
  handleClickTypeAuctionPortalButton: any;
  handleClickTypeAuctionsButton: any;
  isSelectedTypeAuctions: any;
  onEditAuction: (auctionId: string) => void;
  onWithdrawAuction: (auctionId: string) => void;
}) {
  return (
    <>
      <AuctionsPageHeader />
      <div className="auctionPortalsButtons">
        <EbayAuctionsButton
          id={PlatformEnum.EBAY}
          selectedAuctionPortal={selectedAuctionPortal}
          handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
        />
        <AmazonAuctionsButton
          id={PlatformEnum.AMAZON}
          selectedAuctionPortal={selectedAuctionPortal}
          handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
        />
        <OlxAuctionsButton
          id={PlatformEnum.OLX}
          selectedAuctionPortal={selectedAuctionPortal}
          handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
        />
      </div>
      <div className="content">
        <div className="tableAuctions">
          <AuctionsTable
            auctionRecords={auctionRecords}
            isSelectedTypeAuctions={isSelectedTypeAuctions}
            handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
            onEditAuction={onEditAuction}
            onWithdrawAuction={onWithdrawAuction}
          />
        </div>
      </div>
    </>
  );
}
