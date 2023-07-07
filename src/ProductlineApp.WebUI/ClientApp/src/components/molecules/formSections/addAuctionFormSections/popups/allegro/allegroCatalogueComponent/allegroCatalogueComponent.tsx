import React, { useState, useEffect, useRef, ChangeEvent } from 'react';
import './allegroCatalogueComponent.css';
import ActionAreaCard from '../../../../../../atoms/common/card/card';
import { useAuctionsService } from '../../../../../../../hooks/auctions/useAuctionsService';
import {
  AllegroCatalogueProduct,
  Parameter,
} from '../../../../../../../interfaces/platforms/getAllegroCatalogueResponse';
import AllegroSearchInput from '../../../../../../atoms/inputs/allegroSearchProductInput/allegroSearchProductInput';
import { CircularProgress } from '@mui/material';
import NextButton from '../../../../../../atoms/buttons/nextButton/nextButton';
import CancelButton from '../../../../../../atoms/buttons/cancelButton/CancelButton';
import * as Yup from 'yup';

interface AllegroCatalogueComponentProps {
  onProductSelect: (id: string, categoryId: string) => void;
  onNextPage: () => void;
  onCancel: () => void;
}

interface FormData {
  searchPhrase: string;
  selectedProductId: string;
}

const validationSchema = Yup.object().shape({
  searchPhrase: Yup.string().required('Wyszukaj produkt z katalogu'),
  selectedProductId: Yup.string().required('Nalezy wybrac produkt z katalogu'),
});

const AllegroCatalogueComponent: React.FC<AllegroCatalogueComponentProps> = ({
  onProductSelect,
  onNextPage,
  onCancel,
}) => {
  const { auctionsService } = useAuctionsService();
  const [productCatalogue, setProductCatalogue] = useState<AllegroCatalogueProduct[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [formData, setFormData] = useState<FormData>({
    searchPhrase: '',
    selectedProductId: '',
  });
  const [errors, setErrors] = useState<Partial<FormData>>({});

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    if (!formData.searchPhrase) {
      setProductCatalogue([]);
      return;
    }

    setIsLoading(true);
    auctionsService.getAllegoProductCatalogueByPhrase(formData.searchPhrase).then((res) => {
      if (res && res.products) {
        setProductCatalogue(res.products);
      } else {
        setProductCatalogue([]);
      }
      setIsLoading(false);
    });
  };

  const validateForm = async () => {
    try {
      await validationSchema.validate(formData, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<FormData> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof FormData] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  const handleChange = (name: string, value: number | string) => {
    setFormData((prevData) => ({
      ...prevData,
      searchPhrase: value as string,
    }));
  };

  const handleCardClick = (id: string, categoryId: string) => {
    setFormData((prevData) => ({
      ...prevData,
      selectedProductId: id,
    }));
    onProductSelect(id, categoryId);
  };

  const handleOnClick = async () => {
    const isValid = await validateForm();
    console.log(isValid);
    console.log(errors);
    if (!isValid) return;

    onNextPage();
  };

  return (
    <div className="allegroPopupBody">
      <div className="allegroCatalogueComponent">
        <div className="searchRow">
          <AllegroSearchInput
            value={formData.searchPhrase}
            disabled={false}
            onChange={handleChange}
            error={null}
            onSubmit={handleSubmit}
          />
        </div>

        {isLoading && <CircularProgress sx={{ alignSelf: 'center' }} />}

        {productCatalogue.length > 0 && !isLoading && (
          <div className="productList">
            {productCatalogue.map((product, index) => (
              <div className="productCard" key={index}>
                <ActionAreaCard
                  id={product.id}
                  title={product.name}
                  imageUrl={product.images[0]?.url}
                  onCardClick={(id) => handleCardClick(id, product.category.id)}
                  parameters={product.parameters}
                  selectedId={formData.selectedProductId}
                />
              </div>
            ))}
          </div>
        )}
        <div className="error">
          {errors.selectedProductId && <span className="error">{errors.selectedProductId}</span>}
        </div>
      </div>
      <div className="addAuctionAllAllegroButtons">
        <div className="addAuctionAllegroBackButton"></div>
        <div className="addauctionAllegroButtons">
          <CancelButton close={onCancel} />
          <NextButton onClick={handleOnClick} />
        </div>
      </div>
    </div>
  );
};

export default AllegroCatalogueComponent;
