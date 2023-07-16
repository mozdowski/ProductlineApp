import AuctionsTemplate from '../components/templates/AuctionsTemplate';
import { useEffect, useState } from 'react';
import { AuctionsRecord } from '../interfaces/auctions/AuctionsPageInteface';
import { useAuctionsService } from '../hooks/auctions/useAuctionsService';
import { PlatformEnum } from '../enums/platform.enum';
import { Outlet } from 'react-router-dom';
import { usePlatforms } from '../hooks/platforms/usePlatforms';
import { PlatformAuthUrl } from '../interfaces/platforms/platformsAuthUrlResponse';
import AllegroFormPopup from '../components/molecules/formSections/addAuctionFormSections/popups/allegro/AllegroFormPopup';
import { CreateAllegroAuction } from '../interfaces/auctions/createAllegroAuction';
import { toast } from 'react-toastify';
import { WithdrawAuctionRequest } from '../interfaces/auctions/withdrawAuctionRequest';

export default function Auctions() {
  const { platforms, getPlatformByName } = usePlatforms();
  const [selectedAuctionPortal, setSelectedAuctionPortal] = useState<PlatformAuthUrl | undefined>();
  const [isEditPopupOpen, setIsEditPopupOpen] = useState<boolean>(false);
  const [editAuctionValues, setEditAuctionValues] = useState<any>(undefined);
  const [selectedAuctionId, setSelectedAuctionId] = useState<string>();
  const [refreshRecords, setRefreshRecords] = useState<boolean>(false);
  const { auctionsService } = useAuctionsService();
  const [auctions, setAuctions] = useState<AuctionsRecord[]>();
  const [searchValue, setSearchValue] = useState("");

  const handleClickTypeAuctionPortalButton = (platformName: PlatformEnum) => {
    setSelectedAuctionPortal(getPlatformByName(platformName));
  };

  const [showActiveAuctions, setShowActiveAuctions] = useState<boolean>(true);
  const handleClickTypeAuctionsButton = (e: any) => {
    const setActive = e.target.id == 'active';
    setShowActiveAuctions(setActive);

    // if (!auctions || auctions.length === 0) return;
    // setAuctions(auctions.filter(x => x.isActive == setActive));
  };

  const searchTableAuctions = (e: { target: { value: React.SetStateAction<string>; }; }) => {
    setSearchValue(e.target.value)
  }

  const searchAuctions = auctions?.filter(auction => {
    return (
      auction.auctionID.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.sku.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.brand.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.productName.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.category.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.price.toString().indexOf(searchValue) >= 0 ||
      auction.quantity.toString().indexOf(searchValue) >= 0
    )
  });

  useEffect(() => {
    if (platforms) {
      setSelectedAuctionPortal(getPlatformByName(PlatformEnum.EBAY));
    }
  }, [platforms]);

  useEffect(() => {
    if (!selectedAuctionPortal) return;
    setAuctions(undefined);
    auctionsService.getPlatformAuctionsList(selectedAuctionPortal.platformId).then((res) => {
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
        isActive: auction.isActive,
      }));
      setAuctions(auctionsRecords);
    });
  }, [selectedAuctionPortal, refreshRecords, searchValue]);

  const handleEditAuction = async (auctionId: string) => {
    setSelectedAuctionId(auctionId);
    switch (selectedAuctionPortal?.platformName) {
      case PlatformEnum.ALLEGRO: {
        const allegroData = await fetchAllegroData(auctionId);
        setEditAuctionValues(allegroData);
        break;
      }
      case PlatformEnum.EBAY: {
        break;
      }
    }
  };

  const handleWithdrawAuction = async (auctionId: string) => {
    setSelectedAuctionId(auctionId);
    switch (selectedAuctionPortal?.platformName) {
      case PlatformEnum.ALLEGRO: {
        const res = await withdrawAllegroAuction(auctionId);
        break;
      }
      case PlatformEnum.EBAY: {
        break;
      }
    }
  };

  const withdrawAllegroAuction = async (auctionId: string) => {
    const data: WithdrawAuctionRequest = {
      offerId: auctionId,
    };
    try {
      const res = await auctionsService.withdrawAllegroAuction(data);
      toast.success('Pomyślnie wycofano ofertę Allegro');
    } catch {
      toast.error('Błąd podczas wycofywania oferty Allegro');
    }
  };

  const fetchAllegroData = (auctionId: string) => {
    return auctionsService.getAllegroOfferProductDetails(auctionId);
  };

  const handleAllegoAuctionEdit = async (data: CreateAllegroAuction) => {
    if (!selectedAuctionId) return;
    try {
      const res = await auctionsService.updateAllegroAuction(selectedAuctionId, data);
      toast.success('Zaktualizowano aukcję Allegro');
    } catch {
      toast.error('Błąd podczas aktualizowania aukcji Allegro');
    }
    setEditAuctionValues(undefined);
    setRefreshRecords(!refreshRecords);
  };

  return (
    <>
      <Outlet />
      <AuctionsTemplate
        auctionRecords={searchAuctions}
        selectedAuctionPortal={selectedAuctionPortal?.platformName}
        handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
        showActiveAuctions={showActiveAuctions}
        handleClickTypeAuctionsButton={handleClickTypeAuctionsButton}
        onEditAuction={handleEditAuction}
        onWithdrawAuction={handleWithdrawAuction}
        onChange={searchTableAuctions}
        searchValue={searchValue}
      />
      {editAuctionValues && selectedAuctionPortal?.platformName === PlatformEnum.ALLEGRO && (
        <AllegroFormPopup
          closeAllegroPopup={() => setIsEditPopupOpen(false)}
          onSubmit={handleAllegoAuctionEdit}
          initialFormValues={editAuctionValues}
        />
      )}
    </>
  );
}
