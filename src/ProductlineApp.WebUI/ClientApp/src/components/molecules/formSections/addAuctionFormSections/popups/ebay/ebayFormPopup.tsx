import './ebayFormPopup.css';
import EbayLogo from '../../../../../../assets/icons/ebay_icon.svg';
import EbayCategorySelect from './ebayCategorySelect/ebayCategorySelect';
import { useState } from 'react';
import EbayParametersSetComponent from './ebayParametersSetComponent/ebayParametersSetComponent';
import EbayListingDetails from './ebayListingDetails/ebayListingDetails';
import {
  CreateEbayAuctionRequest,
  EbayOfferDetails,
} from '../../../../../../interfaces/auctions/createEbayAuctionRequest';

interface EbayFormPopupProps {
  closePopup: () => void;
  onSubmit: (ebayForm: CreateEbayAuctionRequest) => void;
}

enum PopupPages {
  Category = 0,
  ParametersSet,
  ListingDetails,
}

const EbayFormPopup: React.FC<EbayFormPopupProps> = ({ closePopup, onSubmit }) => {
  const [selectedCategoryid, setSelectedCategoryId] = useState<string>('');
  const [currentPage, setCurrentPage] = useState<PopupPages>(PopupPages.Category);
  const [aspects, setAspects] = useState<Record<string, string[]>>({});

  const handleNextPage = () => {
    const totalPages = Object.keys(PopupPages).length / 2;
    const nextPageIndex = (currentPage + 1) % totalPages;
    setCurrentPage(nextPageIndex as PopupPages);
  };

  const handlePrevPage = () => {
    const totalPages = Object.keys(PopupPages).length / 2;
    const nextPageIndex = (currentPage - 1) % totalPages;
    setCurrentPage(nextPageIndex as PopupPages);
  };

  const handleCancel = () => {
    closePopup();
  };

  const handleCategorySelect = (id: string) => {
    if (!id) return;
    setSelectedCategoryId(id);
    handleNextPage();
  };

  const handleAspectsSelect = (aspects: Record<string, any>) => {
    setAspects(aspects);
    handleNextPage();
  };

  const handleConfirm = (detailsForm: EbayOfferDetails) => {
    const ebayForm: CreateEbayAuctionRequest = {
      listingId: '',
      aspects: aspects,
      offerDetails: detailsForm,
    };

    onSubmit(ebayForm);
    closePopup();
  };

  return (
    <div className="overlayEbayPopup">
      <div
        className="ebayPopup"
        onClick={(e) => {
          e.stopPropagation();
        }}
      >
        <div className="ebayPopupSectionLabel">
          <img src={EbayLogo} className="ebayBrandIcon" />
          {currentPage === PopupPages.Category && <p>Wybierz kategorie z katalogu Ebay</p>}
          {currentPage === PopupPages.ParametersSet && <p>Dostosuj parametry produktu</p>}
        </div>
        {currentPage === PopupPages.Category && (
          <EbayCategorySelect onNext={handleCategorySelect} onCancel={handleCancel} />
        )}
        {selectedCategoryid && currentPage === PopupPages.ParametersSet && (
          <EbayParametersSetComponent
            categoryId={selectedCategoryid}
            onCancel={handleCancel}
            onPrev={handlePrevPage}
            onNext={handleAspectsSelect}
          />
        )}
        {selectedCategoryid && currentPage === PopupPages.ListingDetails && (
          <EbayListingDetails
            onPrevPage={handlePrevPage}
            onConfirm={handleConfirm}
            onCancel={handleCancel}
            categoryId={selectedCategoryid}
          />
        )}
      </div>
    </div>
  );
};

export default EbayFormPopup;
