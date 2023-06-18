import AuctionsTemplate from '../components/templates/AuctionsTemplate';
import { useEffect, useState } from 'react';
import { AuctionsRecord } from '../interfaces/auctions/AuctionsPageInteface';
import { useAuctionsService } from '../hooks/auctions/useAuctionsService';
import { Platform } from '../interfaces/platforms/platform';

export default function Auctions() {
  const [isSelectedAuctionPortal, setIsSelectedAuctionPortal] = useState('');
  const handleClickTypeAuctionPortalButton = (e: any) => {
    setIsSelectedAuctionPortal(e.target.id);
  };

  const [isSelectedTypeAuctions, SetisSelectedTypeAuctions] = useState('');
  const handleClickTypeAuctionsButton = (e: any) => {
    SetisSelectedTypeAuctions(e.target.id);
  };

  const [platforms, setPlatforms] = useState<Platform[] | null>(null);
  const [selectedPlatform, setSelectedPlatform] = useState<Platform | null>(null);

  const { auctionsService } = useAuctionsService();
  const [auctions, setAuctions] = useState<AuctionsRecord[]>([]);

  useEffect(() => {
    const fetchPlatformData = async () => {
      if (!selectedPlatform) {
        const res = await auctionsService.getPlatformsWithListings();
        if (res.platforms.length > 0) {
          setPlatforms(res.platforms);
          setSelectedPlatform(res.platforms[0]);
        }
      }

      if (selectedPlatform) {
        const res = await auctionsService.getPlatformAuctionsList(selectedPlatform.id);
        const auctionsRecords: AuctionsRecord[] = res.listings.map((auction) => ({
          auctionID: auction.listingId,
          sku: auction.sku,
          brand: auction.brand,
          productName: auction.productName,
          category: auction.category,
          price: auction.price,
          quantity: auction.quantity,
          daysToEnd: auction.daysToExpire,
        }));
        setAuctions(auctionsRecords);
      }
    };

    fetchPlatformData();
  }, [selectedPlatform]);

  return (
    <AuctionsTemplate
      auctionRecords={auctions}
      isSelectedAuctionPortal={isSelectedAuctionPortal}
      handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
      isSelectedTypeAuctions={isSelectedTypeAuctions}
      handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
    />
  );
}
