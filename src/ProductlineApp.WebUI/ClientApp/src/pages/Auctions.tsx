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
import EbayFormPopup from '../components/molecules/formSections/addAuctionFormSections/popups/ebay/ebayFormPopup';
import { CreateEbayAuctionRequest } from '../interfaces/auctions/createEbayAuctionRequest';

export default function Auctions() {
  const { platforms, getPlatformByName } = usePlatforms();
  const [selectedAuctionPortal, setSelectedAuctionPortal] = useState<PlatformAuthUrl | undefined>();
  const [editAuctionValues, setEditAuctionValues] = useState<any>(undefined);
  const [selectedAuctionId, setSelectedAuctionId] = useState<string>();
  const [refreshRecords, setRefreshRecords] = useState<boolean>(false);
  const { auctionsService } = useAuctionsService();
  const [auctions, setAuctions] = useState<AuctionsRecord[]>();
  const [searchValue, setSearchValue] = useState('');

  const handleClickTypeAuctionPortalButton = (platformName: PlatformEnum) => {
    setSelectedAuctionPortal(getPlatformByName(platformName));
  };

  const [showActiveAuctions, setShowActiveAuctions] = useState<boolean>(true);
  const handleClickTypeAuctionsButton = (e: any) => {
    const setActive = e.target.id == 'active';
    setShowActiveAuctions(setActive);
  };

  const searchTableAuctions = (e: { target: { value: React.SetStateAction<string> } }) => {
    setSearchValue(e.target.value);
  };

  const searchAuctions = auctions?.filter((auction) => {
    return (
      auction.auctionID.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.sku.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.brand.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.productName.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.category.toLowerCase().indexOf(searchValue) >= 0 ||
      auction.price.toString().indexOf(searchValue) >= 0 ||
      auction.quantity.toString().indexOf(searchValue) >= 0
    );
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
        auctionID: auction.platformListingId,
        sku: auction.sku,
        brand: auction.brand,
        productName: auction.productName,
        category: auction.category,
        price: auction.price,
        quantity: auction.quantity,
        daysToEnd: auction.daysToExpire,
        productImageUrl: auction.productImageUrl,
        isActive: auction.isActive,
        listingId: auction.listingId,
        listingInstanceId: auction.listingInstanceId,
      }));
      setAuctions(auctionsRecords);
    });
  }, [selectedAuctionPortal, refreshRecords, searchValue]);

  const handleEditAuction = async (auctionId: string): Promise<boolean> => {
    setSelectedAuctionId(auctionId);
    switch (selectedAuctionPortal?.platformName) {
      case PlatformEnum.ALLEGRO: {
        const allegroData = await fetchAllegroData(auctionId);
        setEditAuctionValues(allegroData);
        break;
      }
      case PlatformEnum.EBAY: {
        const ebayData = await fetchEbayData(auctionId);
        setEditAuctionValues(ebayData);
        break;
      }
    }
    return true;
  };

  const handleWithdrawAuction = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ): Promise<boolean> => {
    setSelectedAuctionId(auctionId);

    const data: WithdrawAuctionRequest = {
      listingId: listingId,
      listingInstanceiD: listingInstanceId,
    };

    try {
      await toast.promise(
        auctionsService.withdrawAuction(selectedAuctionPortal?.platformId as string, data),
        {
          pending: 'Trwa wycofywanie oferty...',
          success: `Pomyślnie wycofano ofertę ${auctionId}`,
          error: 'Błąd podczas wycofywania oferty',
        },
      );
      setRefreshRecords(!refreshRecords);
    } catch (error) {
      console.error('Błąd podczas wycofywania oferty:', error);
    }

    return true;
  };

  const fetchAllegroData = (auctionId: string) => {
    return auctionsService.getAllegroOfferProductDetails(auctionId);
  };

  const fetchEbayData = (auctionId: string) => {
    return auctionsService.getEbayAuctionDetails(auctionId);
  };

  const handleAllegoAuctionEdit = async (data: CreateAllegroAuction) => {
    if (!selectedAuctionId) return;

    try {
      await toast.promise(auctionsService.updateAllegroAuction(selectedAuctionId, data), {
        pending: 'Trwa aktualizowanie aukcji Allegro...',
        success: 'Zaktualizowano aukcję Allegro',
        error: 'Błąd podczas aktualizowania aukcji Allegro',
      });
    } catch (error) {
      console.error('Błąd podczas aktualizowania aukcji Allegro:', error);
    }

    refreshRecordsState();
  };

  const handleEbayAuctionEdit = async (ebayForm: CreateEbayAuctionRequest) => {
    if (!selectedAuctionId) return;

    try {
      await toast.promise(auctionsService.updateEbayAuction(selectedAuctionId, ebayForm), {
        pending: 'Trwa aktualizowanie aukcji Ebay...',
        success: 'Zaktualizowano aukcję Ebay',
        error: 'Błąd podczas aktualizowania aukcji Ebay',
      });
    } catch (error) {
      console.error('Błąd podczas aktualizowania aukcji Ebay:', error);
    }

    refreshRecordsState();
  };

  const refreshRecordsState = () => {
    setEditAuctionValues(undefined);
    setSelectedAuctionId('');
    setRefreshRecords((prev) => !prev);
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
      {editAuctionValues && (
        <>
          {selectedAuctionPortal?.platformName === PlatformEnum.ALLEGRO && (
            <AllegroFormPopup
              closeAllegroPopup={() => setEditAuctionValues(undefined)}
              onSubmit={handleAllegoAuctionEdit}
              initialFormValues={editAuctionValues}
            />
          )}
          {selectedAuctionPortal?.platformName === PlatformEnum.EBAY && (
            <EbayFormPopup
              closePopup={() => setEditAuctionValues(undefined)}
              onSubmit={handleEbayAuctionEdit}
              initialFormValues={editAuctionValues}
            />
          )}
        </>
      )}
    </>
  );
}
