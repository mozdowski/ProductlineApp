import './css/allegroFormPopup.css';
import AllegroLogo from '../../../../../../assets/icons/allegroLogo_icon.svg';
import { useState } from 'react';
import AllegroCatalogueComponent from './allegroCatalogueComponent/allegroCatalogueComponent';
import ParametersSetComponent from './parametersSetComponent/parametersSetComponent';
import AllegroListingDetails, {
  AllegroListingDetailsFormData,
} from './allegroListingDetails/allegroListingDetails';
import {
  CreateAllegroAuction,
  Parameter,
} from '../../../../../../interfaces/auctions/createAllegroAuction';

interface AllegroFormPopupProps {
  openAllegroPopup: boolean;
  closeAllegroPopup: () => void;
  onSubmit: (form: CreateAllegroAuction) => void;
}

export interface ParameterResponseModel {
  name: string;
  valueIds?: string[];
  values?: string[];
}

enum PopupPages {
  ProductSelect = 0,
  ParametersSet,
  ListingDetails,
}

const AllegroFormPopup: React.FC<AllegroFormPopupProps> = ({
  openAllegroPopup,
  closeAllegroPopup,
  onSubmit,
}) => {
  const [currentPage, setCurrentPage] = useState<PopupPages>(PopupPages.ProductSelect);
  const [selectedProductId, setSelectedProductId] = useState<string | null>(null);
  const [selelectedCategoryId, setSelectedCategoryId] = useState<string | null>(null);
  const [prodParameters, setProdParameters] = useState<Parameter[]>([]);
  const [listParameters, setListParameters] = useState<Parameter[]>([]);

  // const [allegroListingForm, setAllegroListingForm] = useState<CreateAllegroAuction | null>(null);

  const handleNextPage = (
    productParameters?: ParameterResponseModel[],
    listingParameters?: ParameterResponseModel[],
  ) => {
    const totalPages = Object.keys(PopupPages).length / 2;
    const nextPageIndex = (currentPage + 1) % totalPages;
    setCurrentPage(nextPageIndex as PopupPages);

    if (!productParameters || !listingParameters) return;

    setProdParameters(
      productParameters.map((x) => ({
        name: x.name,
        values: x.values,
        valuesIds: x.valueIds,
      })),
    );

    setListParameters(
      listingParameters.map((x) => ({
        name: x.name,
        values: x.values,
        valuesIds: x.valueIds,
      })),
    );
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

  const handleConfirm = (detailsForm: AllegroListingDetailsFormData) => {
    const allegroListingData: CreateAllegroAuction = {
      listingId: '',
      name: detailsForm.name,
      allegroProductId: selectedProductId as string,
      description: '',
      impliedWarrantyId: detailsForm.impliedWarrantyId,
      returnPolicyId: detailsForm.returnPolicyId,
      price: detailsForm.price,
      location: {
        city: detailsForm.locationCity,
        countryCode: detailsForm.locationCountryCode,
        postCode: detailsForm.locationPostCode,
        province: detailsForm.locationProvince,
      },
      productId: '',
      productParameters: prodParameters,
      listingParameters: listParameters,
      duration: detailsForm.duration,
      republish: detailsForm.republish,
      imagesUrls: [],
      shippingRateId: detailsForm.shippingRateId,
      quantity: detailsForm.quantity,
    };

    console.log(allegroListingData);

    onSubmit(allegroListingData);
    closeAllegroPopup();
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
          {currentPage === PopupPages.ListingDetails && (
            <AllegroListingDetails
              onConfirm={handleConfirm}
              onPrevPage={handlePrevPage}
              onCancel={closeAllegroPopup}
            />
          )}
        </div>
      </div>
    </div>
  );
};
AllegroListingDetails;
export default AllegroFormPopup;
