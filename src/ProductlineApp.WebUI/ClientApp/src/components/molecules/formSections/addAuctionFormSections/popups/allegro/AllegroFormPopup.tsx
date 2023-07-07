import './css/allegroFormPopup.css';
import AllegroLogo from '../../../../../../assets/icons/allegroLogo_icon.svg';
import CancelButton from '../../../../../atoms/buttons/cancelButton/CancelButton';
import ConfrimButton from '../../../../../atoms/buttons/confirmButton/ConfirmButton';
import { AuctionForm } from '../../../../../../interfaces/auctions/auctionForm';
import { useState } from 'react';
import NextButton from '../../../../../atoms/buttons/nextButton/nextButton';
import AllegroCatalogueComponent from './allegroCatalogueComponent/allegroCatalogueComponent';
import ParametersSetComponent from './parametersSetComponent/parametersSetComponent';
import BackButton from '../../../../../atoms/buttons/backButton/backButton';

interface AllegroFormPopupProps {
  openAllegroPopup: boolean;
  closeAllegroPopup: () => void;
  errors: Partial<AuctionForm>;
}

enum PopupPages {
  ProductSelect = 0,
  ParametersSet,
  ListingDetails,
}

const AllegroFormPopup: React.FC<AllegroFormPopupProps> = ({
  openAllegroPopup,
  closeAllegroPopup,
  errors,
}) => {
  const [currentPage, setCurrentPage] = useState<PopupPages>(PopupPages.ProductSelect);
  const [selectedProductId, setSelectedProductId] = useState<string | null>(null);
  const [selelectedCategoryId, setSelectedCategoryId] = useState<string | null>(null);

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

  const handleProductSelect = (id: string, categoryId: string) => {
    if (!id || !categoryId) return;
    setSelectedProductId(id);
    setSelectedCategoryId(categoryId);
  };

  if (!openAllegroPopup) return null;
  return (
    <div className="overlayAllegroPopup">
      <div
        className="allegroPopup"
        onClick={(e) => {
          e.stopPropagation();
        }}
      >
        <div className="allegroPopupSectionLabel">
          <img src={AllegroLogo} className="allegroBrandIcon" />
          {currentPage === PopupPages.ProductSelect && <p>Wybierz produkt z katalogu Allegro</p>}
          {currentPage === PopupPages.ParametersSet && <p>Dostosuj parametry produktu</p>}
        </div>
        <div className="allegroPopupBody">
          {currentPage === PopupPages.ProductSelect && (
            <AllegroCatalogueComponent
              onProductSelect={handleProductSelect}
              onNextPage={handleNextPage}
              onCancel={closeAllegroPopup}
            />
          )}
          {currentPage === PopupPages.ParametersSet &&
            selelectedCategoryId &&
            selectedProductId && (
              <ParametersSetComponent
                categoryId={selelectedCategoryId}
                productId={selectedProductId}
                onPrevPage={handlePrevPage}
                onNextPage={handleNextPage}
                onCancel={closeAllegroPopup}
              />
            )}
        </div>
      </div>
    </div>
  );
};

export default AllegroFormPopup;
