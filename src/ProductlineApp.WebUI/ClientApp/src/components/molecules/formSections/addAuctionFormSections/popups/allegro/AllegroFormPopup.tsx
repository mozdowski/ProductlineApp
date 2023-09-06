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
  AllegroBasicParameter,
} from '../../../../../../interfaces/auctions/createAllegroAuction';
import { useSelectedProduct } from '../../../../../../hooks/auctions/useSelectedProduct';
import { AllegroOfferProductDetailsResponse } from '../../../../../../interfaces/auctions/allegroOfferProductDetailsResponse';

interface AllegroFormPopupProps {
  closeAllegroPopup: () => void;
  onSubmit: (form: CreateAllegroAuction) => void;
  initialFormValues?: AllegroOfferProductDetailsResponse;
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
  closeAllegroPopup,
  onSubmit,
  initialFormValues,
}) => {
  const [currentPage, setCurrentPage] = useState<PopupPages>(
    initialFormValues ? PopupPages.ParametersSet : PopupPages.ProductSelect,
  );
  const [selectedAllegroProductId, setSelectedAllegroProductId] = useState<string | null>(
    initialFormValues ? initialFormValues.allegroProductId : null,
  );
  const [selelectedCategoryId, setSelectedCategoryId] = useState<string | null>(
    initialFormValues ? initialFormValues.categoryId : null,
  );
  const [prodParameters, setProdParameters] = useState<AllegroBasicParameter[]>([]);
  const [listParameters, setListParameters] = useState<AllegroBasicParameter[]>([]);

  const product = {
    id: '',
    imageUrls: [''],
    description: '',
  };

  if (initialFormValues) {
    product.description = initialFormValues.description;
    product.imageUrls = initialFormValues.imagesUrls;
    product.id = initialFormValues.productId;
  } else {
    const { selectedProduct } = useSelectedProduct();
    product.description = selectedProduct.description;
    product.imageUrls = selectedProduct.imageUrls;
    product.id = selectedProduct.id;
  }

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
    setSelectedAllegroProductId(id);
    setSelectedCategoryId(categoryId);
  };

  const handleConfirm = (detailsForm: AllegroListingDetailsFormData) => {
    const allegroListingData: CreateAllegroAuction = {
      listingId: '',
      name: detailsForm.name,
      allegroProductId: selectedAllegroProductId as string,
      description: detailsForm.description,
      impliedWarrantyId: detailsForm.impliedWarrantyId,
      returnPolicyId: detailsForm.returnPolicyId,
      price: detailsForm.price,
      location: {
        city: detailsForm.locationCity,
        countryCode: detailsForm.locationCountryCode,
        postCode: detailsForm.locationPostCode,
        province: detailsForm.locationProvince,
      },
      productId: product.id,
      productParameters: prodParameters,
      listingParameters: listParameters,
      duration: detailsForm.duration,
      republish: detailsForm.republish,
      imagesUrls: product.imageUrls,
      shippingRateId: detailsForm.shippingRateId,
      quantity: detailsForm.quantity,
    };

    onSubmit(allegroListingData);
    closeAllegroPopup();
  };

  const handleCancel = () => {
    closeAllegroPopup();
  };

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
          {currentPage === PopupPages.ProductSelect && <p className="allegroPopUpInfoText">Wybierz produkt z katalogu Allegro</p>}
          {currentPage === PopupPages.ParametersSet && <p className="allegroPopUpInfoText">Dostosuj parametry produktu</p>}
          {currentPage === PopupPages.ListingDetails && <p className="allegroPopUpInfoText">Dostosuj parametry oferty</p>}
        </div>
        <div className="allegroPopupBody">
          {currentPage === PopupPages.ProductSelect && (
            <AllegroCatalogueComponent
              onProductSelect={handleProductSelect}
              onNextPage={handleNextPage}
              onCancel={handleCancel}
            />
          )}
          {currentPage === PopupPages.ParametersSet &&
            selelectedCategoryId &&
            selectedAllegroProductId && (
              <ParametersSetComponent
                categoryId={initialFormValues ? initialFormValues.categoryId : selelectedCategoryId}
                productId={
                  initialFormValues ? initialFormValues.allegroProductId : selectedAllegroProductId
                }
                onPrevPage={handlePrevPage}
                onNextPage={handleNextPage}
                onCancel={handleCancel}
                initValues={
                  initialFormValues
                    ? [
                      ...initialFormValues.productParameters,
                      ...initialFormValues.listingParameters,
                    ]
                    : undefined
                }
              />
            )}
          {currentPage === PopupPages.ListingDetails && (
            <AllegroListingDetails
              onConfirm={handleConfirm}
              onPrevPage={handlePrevPage}
              onCancel={handleCancel}
              initValues={initialFormValues ? initialFormValues : undefined}
            />
          )}
        </div>
      </div>
    </div>
  );
};
export default AllegroFormPopup;
