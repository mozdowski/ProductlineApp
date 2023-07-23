import './css/AuctionsTemplate.css';
import { AuctionsRecord } from '../../interfaces/auctions/AuctionsPageInteface';
import AuctionsPageHeader from '../organisms/pageHeaders/AuctionsPageHeader';
import AuctionsTable from '../organisms/tables/AuctionsTable';
import EbayAuctionsButton from '../atoms/buttons/auctionPortalsButtons/EbayAuctionsButton';
import { PlatformEnum } from '../../enums/platform.enum';
import AllegroAuctionsButton from '../atoms/buttons/auctionPortalsButtons/AllegroAuctionsButton';

export default function AuctionsTemplate({
  auctionRecords,
  selectedAuctionPortal,
  handleClickTypeAuctionPortalButton,
  onAuctionStateClick,
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
  onAuctionStateClick: (showActive: boolean) => void;
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
            onAuctionStateClick={onAuctionStateClick}
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
