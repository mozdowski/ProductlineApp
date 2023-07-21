import './css/AuctionsTemplate.css';
import { AuctionsRecord } from '../../interfaces/auctions/AuctionsPageInteface';
import AuctionsPageHeader from '../organisms/pageHeaders/AuctionsPageHeader';
import AuctionsTable from '../organisms/tables/AuctionsTable';
import AmazonAuctionsButton from '../atoms/buttons/auctionPortalsButtons/AmazonAuctionsButton';
import EbayAuctionsButton from '../atoms/buttons/auctionPortalsButtons/EbayAuctionsButton';
import OlxAuctionsButton from '../atoms/buttons/auctionPortalsButtons/OlxAuctionsButton';
import { Platform } from '../../interfaces/platforms/platform';
import { PlatformEnum } from '../../enums/platform.enum';
import AllegroAuctionsButton from '../atoms/buttons/auctionPortalsButtons/AllegroAuctionsButton';

export default function AuctionsTemplate({
  auctionRecords,
  selectedAuctionPortal,
  handleClickTypeAuctionPortalButton,
  handleClickTypeAuctionsButton,
  onEditAuction,
  onWithdrawAuction,
  showActiveAuctions,
  searchValue,
  onChange,
  isDataLoaded,
  onAuctionReactivate,
}: {
  auctionRecords?: AuctionsRecord[];
  selectedAuctionPortal?: PlatformEnum;
  handleClickTypeAuctionPortalButton: any;
  handleClickTypeAuctionsButton: any;
  onEditAuction: (auctionId: string) => Promise<boolean>;
  onWithdrawAuction: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
  showActiveAuctions: boolean;
  searchValue: string;
  onChange: (e: any) => void;
  isDataLoaded: boolean;
  onAuctionReactivate: (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => Promise<boolean>;
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
          handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
        />
      </div>
      <div className="content">
        <div className="tableAuctions">
          <AuctionsTable
            auctionRecords={auctionRecords}
            handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
            onEditAuction={onEditAuction}
            onWithdrawAuction={onWithdrawAuction}
            showActiveAuctions={showActiveAuctions}
            searchValue={searchValue}
            onChange={onChange}
            isDataLoaded={isDataLoaded}
            onAuctionReactivate={onAuctionReactivate}
          />
        </div>
      </div>
    </>
  );
}
