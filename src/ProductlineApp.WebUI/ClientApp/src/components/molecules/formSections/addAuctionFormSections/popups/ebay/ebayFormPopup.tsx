import './ebayFormPopup.css';
import EbayLogo from '../../../../../../assets/icons/ebay_icon.svg';
import { useAuctionsService } from '../../../../../../hooks/auctions/useAuctionsService';
import EbayCategorySelect from './ebayCategorySelect/ebayCategorySelect';
import { useState } from 'react';
import EbayParametersSetComponent from './ebayParametersSetComponent/ebayParametersSetComponent';
import AutocompleteComboBox from '../../../../../atoms/common/autocomplete/autocomplete';

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

  const handleAspectsSelect = (aspects: { [index: string]: any }) => {
    console.log(aspects);
    handleNextPage();
  }

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
          <EbayParametersSetComponent categoryId={selectedCategoryid} onCancel={handleCancel} onPrev={handlePrevPage} onNext={handleAspectsSelect}/>
        )}
        {/* {selectedCategoryid && currentPage === PopupPages.ListingDetails && (
        )} */}
      </div>
    </div>
  );
};

export default EbayFormPopup;
