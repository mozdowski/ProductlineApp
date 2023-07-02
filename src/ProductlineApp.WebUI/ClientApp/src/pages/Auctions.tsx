import AuctionsTemplate from '../components/templates/AuctionsTemplate';
import { useEffect, useState } from 'react';
import { AuctionsRecord } from '../interfaces/auctions/AuctionsPageInteface';
import { useAuctionsService } from '../hooks/auctions/useAuctionsService';
import { Platform } from '../interfaces/platforms/platform';
import { PlatformEnum } from '../enums/platform.enum';
import { Outlet } from 'react-router-dom';

export default function Auctions() {
  const [selectedAuctionPortal, setSelectedAuctionPortal] = useState<Platform | null>(null);

  const handleClickTypeAuctionPortalButton = (platformName: PlatformEnum) => {
    setSelectedAuctionPortal(
      Object.assign(
        {},
        platforms?.find((p) => p.name === platformName),
      ),
    );
  };

  const [isSelectedTypeAuctions, SetisSelectedTypeAuctions] = useState('');
  const handleClickTypeAuctionsButton = (e: any) => {
    SetisSelectedTypeAuctions(e.target.id);
  };

  const [platforms, setPlatforms] = useState<Platform[] | null>(null);

  const { auctionsService } = useAuctionsService();
  const [auctions, setAuctions] = useState<AuctionsRecord[]>([]);

  useEffect(() => {
    if (!platforms) {
      auctionsService.getPlatforms().then((res) => {
        if (res.platforms.length > 0) {
          setPlatforms(res.platforms);
          setSelectedAuctionPortal(
            res.platforms.find((p) => p.name === PlatformEnum.EBAY) as Platform,
          );
        }
      });
    }
  }, [platforms]);

  useEffect(() => {
    if (selectedAuctionPortal) {
      auctionsService.getPlatformAuctionsList(selectedAuctionPortal.id).then((res) => {
        const auctionsRecords: AuctionsRecord[] = res.listings.map((auction) => ({
          auctionID: auction.listingId,
          sku: auction.sku,
          brand: auction.brand,
          productName: auction.productName,
          category: auction.category,
          price: auction.price,
          quantity: auction.quantity,
          daysToEnd: auction.daysToExpire,
          productImageUrl: auction.productImageUrl,
        }));
        setAuctions(auctionsRecords);
      });
    }
  }, [selectedAuctionPortal]);

  return (
    <>
      <Outlet />
      <AuctionsTemplate
        auctionRecords={auctions}
        selectedAuctionPortal={selectedAuctionPortal ? selectedAuctionPortal.name : PlatformEnum.EBAY}
        handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
        isSelectedTypeAuctions={isSelectedTypeAuctions}
        handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
      />
    </>
  );
}
