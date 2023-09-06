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
import {
  ReactivateAuctionRequest,
  WithdrawAuctionRequest,
} from '../interfaces/auctions/withdrawAuctionRequest';
import EbayFormPopup from '../components/molecules/formSections/addAuctionFormSections/popups/ebay/ebayFormPopup';
import { CreateEbayAuctionRequest } from '../interfaces/auctions/createEbayAuctionRequest';
import { useConfirmationPopup } from '../hooks/popups/useConfirmationPopup';
import { TabTitle } from '../helpers/changePageTitle';

export default function Auctions() {
  TabTitle('productline. Aukcje');

  const { platforms, getPlatformByName } = usePlatforms();
  const [selectedAuctionPortal, setSelectedAuctionPortal] = useState<PlatformAuthUrl | undefined>();
  const [editAuctionValues, setEditAuctionValues] = useState<any>(undefined);
  const [selectedAuctionId, setSelectedAuctionId] = useState<string>();
  const [refreshRecords, setRefreshRecords] = useState<boolean>(false);
  const { auctionsService } = useAuctionsService();
  const [auctions, setAuctions] = useState<AuctionsRecord[]>();
  const [searchValue, setSearchValue] = useState('');
  const [isDataLoaded, setIsDataLoaded] = useState<boolean>(false);

  const handleClickTypeAuctionPortalButton = async (platformName: PlatformEnum) => {
    if (!isDataLoaded) return;

    const selectedPlatform = getPlatformByName(platformName);
    setSelectedAuctionPortal(selectedPlatform);

    setAuctions(undefined);
    setIsDataLoaded(false);
  };

  const [showActiveAuctions, setShowActiveAuctions] = useState<boolean>(true);

  const handleAuctionStateClick = (showActive: boolean) => {
    setShowActiveAuctions(showActive);
  };

  const searchTableAuctions = (e: { target: { value: React.SetStateAction<string> } }) => {
    setSearchValue(e.target.value);
  };

  const searchAuctions = auctions
    ?.filter((auction) => {
      return (
        auction.auctionID.toLowerCase().indexOf(searchValue) >= 0 ||
        auction.sku.toLowerCase().indexOf(searchValue) >= 0 ||
        auction.brand.toLowerCase().indexOf(searchValue) >= 0 ||
        auction.productName.toLowerCase().indexOf(searchValue) >= 0 ||
        auction.category.toLowerCase().indexOf(searchValue) >= 0 ||
        auction.price.toString().indexOf(searchValue) >= 0 ||
        auction.quantity.toString().indexOf(searchValue) >= 0
      );
    })
    .filter((x) => x.isActive == showActiveAuctions);

  useEffect(() => {
    if (selectedAuctionPortal) return;
    if (platforms) {
      setSelectedAuctionPortal(getPlatformByName(PlatformEnum.EBAY));
    }
  }, [platforms]);

  useEffect(() => {
    if (isDataLoaded) return;

    fetchAuctionRecords();
  }, [refreshRecords, selectedAuctionPortal]);

  const fetchAuctionRecords = async () => {
    if (!selectedAuctionPortal) return;
    try {
      const res = await auctionsService.getPlatformAuctionsList(selectedAuctionPortal?.platformId);
      const auctionRecords: AuctionsRecord[] = res.listings.map((auction) => ({
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
      setAuctions(auctionRecords);
    } catch {
      toast.error('Blad podczas pobierania listy aukcji...');
    }

    setIsDataLoaded(true);
  };

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

  const { showConfirmation } = useConfirmationPopup();

  const handleShowWithdrawConfirmation = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => {
    const confirmationText = 'Czy na pewno chcesz wycofać ofertę?';
    showConfirmation(
      confirmationText,
      async () => await withdrawAuction(listingId, listingInstanceId, auctionId),
    );
  };

  const withdrawAuction = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ) => {
    setSelectedAuctionId(auctionId);

    const data: WithdrawAuctionRequest = {
      listingId: listingId,
      listingInstanceiD: listingInstanceId,
    };

    try {
      await toast.promise(
        Promise.all([
          auctionsService.withdrawAuction(selectedAuctionPortal?.platformId as string, data),
          new Promise((resolve) => setTimeout(resolve, 3000)),
        ]),
        {
          pending: 'Trwa wycofywanie oferty...',
          success: `Pomyślnie wycofano ofertę ${auctionId}`,
          error: 'Błąd podczas wycofywania oferty',
        },
      );
      refreshRecordsState();
    } catch (error) {
      console.error('Błąd podczas wycofywania oferty:', error);
    }
  };

  const handleWithdrawAuction = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ): Promise<boolean> => {
    await handleShowWithdrawConfirmation(listingId, listingInstanceId, auctionId);
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
      await toast.promise(
        Promise.all([
          auctionsService.updateAllegroAuction(selectedAuctionId, data),
          new Promise((resolve) => setTimeout(resolve, 3000)),
        ]),
        {
          pending: 'Trwa aktualizowanie aukcji Allegro...',
          success: 'Zaktualizowano aukcję Allegro',
          error: 'Błąd podczas aktualizowania aukcji Allegro',
        },
      );
    } catch (error) {
      console.error('Błąd podczas aktualizowania aukcji Allegro:', error);
    }

    refreshRecordsState();
  };

  const handleEbayAuctionEdit = async (ebayForm: CreateEbayAuctionRequest) => {
    if (!selectedAuctionId) return;

    try {
      await toast.promise(
        Promise.all([
          auctionsService.updateEbayAuction(selectedAuctionId, ebayForm),
          new Promise((resolve) => setTimeout(resolve, 3000)),
        ]),
        {
          pending: 'Trwa aktualizowanie aukcji Ebay...',
          success: 'Zaktualizowano aukcję Ebay',
          error: 'Błąd podczas aktualizowania aukcji Ebay',
        },
      );
    } catch (error) {
      console.error('Błąd podczas aktualizowania aukcji Ebay:', error);
    }

    refreshRecordsState();
  };

  const refreshRecordsState = () => {
    setAuctions(undefined);
    setEditAuctionValues(undefined);
    setSelectedAuctionId('');
    setRefreshRecords((prev) => !prev);
    setIsDataLoaded(false);
  };

  const handleAuctionReactivate = async (
    listingId: string,
    listingInstanceId: string,
    auctionId: string,
  ): Promise<boolean> => {
    setSelectedAuctionId(auctionId);

    const data: ReactivateAuctionRequest = {
      listingId: listingId,
      listingInstanceiD: listingInstanceId,
    };

    try {
      await toast.promise(
        Promise.all([
          auctionsService.reactivateAuction(selectedAuctionPortal?.platformId as string, data),
          new Promise((resolve) => setTimeout(resolve, 3000)),
        ]),
        {
          pending: 'Trwa aktywacja oferty...',
          success: `Pomyślnie aktywowano ofertę ${auctionId}`,
          error: 'Błąd podczas aktywowania oferty',
        },
      );
      refreshRecordsState();
    } catch (error) {
      console.error('Błąd podczas aktywowania oferty:', error);
    }

    return true;
  };

  return (
    <>
      <Outlet />
      <AuctionsTemplate
        auctionRecords={searchAuctions}
        selectedAuctionPortal={selectedAuctionPortal?.platformName}
        handleClickTypeAuctionPortalButton={handleClickTypeAuctionPortalButton}
        showActiveAuctions={showActiveAuctions}
        onAuctionStateClick={handleAuctionStateClick}
        onEditAuction={handleEditAuction}
        onWithdrawAuction={handleWithdrawAuction}
        onChange={searchTableAuctions}
        searchValue={searchValue}
        isDataLoaded={isDataLoaded}
        onAuctionReactivate={handleAuctionReactivate}
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
