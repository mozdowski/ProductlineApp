import './css/AuctionsTemplate.css';
import { AuctionsRecord } from '../../interfaces/auctions/AuctionsPageInteface';
import AuctionsPageHeader from '../organisms/pageHeaders/AuctionsPageHeader';
import AuctionsTable from '../organisms/tables/AuctionsTable';
import AmazonAuctionsButton from '../atoms/buttons/auctionPortalsButtons/AmazonAuctionsButton';
import EbayAuctionsButton from '../atoms/buttons/auctionPortalsButtons/EbayAuctionsButton';
import OlxAuctionsButton from '../atoms/buttons/auctionPortalsButtons/OlxAuctionsButton';
import { PlatformEnum } from '../../enums/platform.enum';
import AllegroAuctionsButton from '../atoms/buttons/auctionPortalsButtons/AllegroAuctionsButton';

export default function AuctionsTemplate({
  auctionRecords,
  selectedAuctionPortal,
  handleClickTypeAuctionPortalButton,
  handleClickTypeAuctionsButton,
  showActiveAuctions,
  onEditAuction,
  onWithdrawAuction,
}: {
  auctionRecords?: AuctionsRecord[];
  selectedAuctionPortal?: PlatformEnum;
  handleClickTypeAuctionPortalButton: any;
  handleClickTypeAuctionsButton: any;
  showActiveAuctions: boolean;
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
        <AllegroAuctionsButton
          id={PlatformEnum.ALLEGRO}
          selectedAuctionPortal={selectedAuctionPortal}
          handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton} />
      </div>
      <div className="content">
        <div className="tableAuctions">
          <AuctionsTable
            auctionRecords={auctionRecords}
            showActiveAuctions={showActiveAuctions}
            handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
            onEditAuction={onEditAuction}
            onWithdrawAuction={onWithdrawAuction}
          />
        </div>
      </div>
    </>
  );
}
