import './ebayFormPopup.css';
import EbayLogo from '../../../../../../assets/icons/ebay_icon.svg';
import { useAuctionsService } from '../../../../../../hooks/auctions/useAuctionsService';
import EbayCategorySelect from './ebayCategorySelect/ebayCategorySelect';
import { useState } from 'react';

interface EbayFormPopupProps {
  closePopup: () => void;
  onSubmit: (form: any) => void;
}

enum PopupPages {
  Category = 0,
  ParametersSet,
  ListingDetails,
}

const EbayFormPopup: React.FC<EbayFormPopupProps> = ({ closePopup, onSubmit }) => {
  const { auctionsService } = useAuctionsService();
  const [selectedCategoryid, setSelectedCategoryId] = useState<string>('');
  const [currentPage, setCurrentPage] = useState<PopupPages>(PopupPages.Category);

  const handleConfirm = (detailsForm: any) => {
    onSubmit(detailsForm);
    closePopup();
  };

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
        </div>
        {currentPage === PopupPages.Category && (
          <EbayCategorySelect onNext={handleCategorySelect} onCancel={handleCancel} />
        )}
        {currentPage === PopupPages.ParametersSet && (
          <EbayCategorySelect onNext={handleCategorySelect} onCancel={handleCancel} />
        )}
      </div>
    </div>
  );
};

export default EbayFormPopup;
