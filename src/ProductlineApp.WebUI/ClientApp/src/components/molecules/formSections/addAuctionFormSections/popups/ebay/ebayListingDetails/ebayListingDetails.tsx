import CancelButton from '../../../../../../atoms/buttons/cancelButton/CancelButton';
import { useEffect, useState } from 'react';
import BackButton from '../../../../../../atoms/buttons/backButton/backButton';
import * as Yup from 'yup';
import { CircularProgress } from '@mui/material';
import FormInput from '../../../../../../atoms/common/formInput/formInput';
import { FormSelect } from '../../../../../../atoms/common/formSelect/formSelect';
import { useAuctionsService } from '../../../../../../../hooks/auctions/useAuctionsService';
import './ebayListingDetails.css';
import ConfrimButton from '../../../../../../atoms/buttons/confirmButton/ConfirmButton';
import { useSelectedProduct } from '../../../../../../../hooks/auctions/useSelectedProduct';
import { FormTextarea } from '../../../../../../atoms/common/formTextArea/formTextArea';
import { EbayUserPoliciesResponse } from '../../../../../../../interfaces/auctions/ebayUserPoliciesResponse';
import { EbayOfferDetails } from '../../../../../../../interfaces/auctions/createEbayAuctionRequest';

export interface EbayListingDetailsFormData {
  description: string;
  quantity: number;
  quantityLimitPerBuyer?: number;
  price: number;
  fulfillmentPolicyId: string;
  paymentPolicyId: string;
  returnPolicyId: string;
  locationKey: string;
}

interface EbayListingDetailsProps {
  onPrevPage: () => void;
  onConfirm: (offerDetails: EbayOfferDetails) => void;
  onCancel: () => void;
  categoryId: string;
  initValues?: any;
}

const EbayListingDetails: React.FC<EbayListingDetailsProps> = ({
  onPrevPage,
  onConfirm,
  onCancel,
  categoryId,
  initValues,
}) => {
  let product = {
    price: 0,
    quantity: 0,
    description: '',
  };

  if (initValues) {
    product.price = initValues.price;
    product.quantity = initValues.quantity;
    product.description = initValues.description;
  } else {
    const { selectedProduct } = useSelectedProduct();
    product.price = selectedProduct.price;
    product.quantity = selectedProduct.quantity;
    product.description = selectedProduct.description;
  }

  const [formData, setFormData] = useState<EbayListingDetailsFormData>({
    description: initValues ? initValues.description : product.description,
    quantity: initValues ? initValues.quantity : product.quantity,
    quantityLimitPerBuyer: initValues ? initValues.quantity : undefined,
    price: initValues ? initValues.price : product.price,
    fulfillmentPolicyId: initValues ? initValues.fulfillmentPolicyId : '',
    paymentPolicyId: initValues ? initValues.paymentPolicyId : '',
    returnPolicyId: initValues ? initValues.returnPolicyId : '',
    locationKey: initValues ? initValues.locationKey : '',
  });
  const [errors, setErrors] = useState<Partial<EbayListingDetailsFormData>>({});
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [userPolicies, setUserPolicies] = useState<EbayUserPoliciesResponse>({
    fulfillmentPolicies: [],
    paymentPolicies: [],
    returnPolicies: [],
    locationKeys: [],
  });

  const { auctionsService } = useAuctionsService();

  useEffect(() => {
    setIsLoading(true);
    auctionsService.getEbayUserPolicies().then((res) => {
      setUserPolicies(res);
      setFormData((prev) => ({
        ...prev,
        fulfillmentPolicyId:
          res.fulfillmentPolicies.length > 0 ? res.fulfillmentPolicies[0].id : '',
        returnPolicyId: res.returnPolicies.length > 0 ? res.returnPolicies[0].id : '',
        paymentPolicyId: res.paymentPolicies.length > 0 ? res.paymentPolicies[0].id : '',
        locationKey: res.locationKeys.length > 0 ? res.locationKeys[0].id : '',
      }));
      setIsLoading(false);
    });
  }, []);

  const validationSchema = Yup.object().shape({
    description: Yup.string().required('Pole wymagane'),
    quantity: Yup.number()
      .nullable()
      .typeError('Nieprawidłowy format')
      .integer()
      .required('Pole wymagane')
      .positive('Wartość musi być większa od 0'),
    quantityLimitPerBuyer: Yup.mixed().test(
      'is-valid-quantity-limit',
      'Nieprawidłowa wartość',
      function (value) {
        const { quantity } = this.parent;
        if (value === null || value === undefined) {
          return true;
        }
        return value <= quantity;
      },
    ),
    price: Yup.number()
      .typeError('Nieprawidłowy format ceny')
      .required('Pole wymagane')
      .positive('Wartość musi być większa od 0')
      .moreThan(0, 'Wartość musi być większa od 0')
      .test(
        'is-doubled-price',
        'Cena nie moze byc wieksza niz ' + product.price * 3,
        (value: any) => {
          if (!initValues) {
            return true;
          } else {
            return value <= product.price * 3;
          }
        },
      )
      .nullable(),
    paymentPolicyId: Yup.string().required('Pole wymagane'),
    returnPolicyId: Yup.string().required('Pole wymagane'),
    locationKey: Yup.string().required('Pole wymagane'),
  });

  const validateForm = async () => {
    if (!validationSchema) return false;
    try {
      await validationSchema.validate(formData, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<EbayListingDetailsFormData> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof EbayListingDetailsFormData] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const isValid = await validateForm();
    if (!isValid) return;

    const ebayOfferDetails: EbayOfferDetails = {
      listingDescription: formData.description,
      quantity: formData.quantity,
      quantityLimitPerBuyer: formData.quantityLimitPerBuyer,
      categoryId: categoryId,
      price: formData.price,
      fulfillmentPolicyId: formData.fulfillmentPolicyId,
      paymentPolicyId: formData.paymentPolicyId,
      returnPolicyId: formData.returnPolicyId,
      locationKey: formData.locationKey,
    };

    onConfirm(ebayOfferDetails);
  };

  const handleChange = (name: string, value: any) => {
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  return (
    <div className="ebayPopupBody">
      <form onSubmit={handleSubmit}>
        {isLoading && (
          <div className="loadingCircle">
            <CircularProgress />
          </div>
        )}
        {!isLoading && (
          <div className="ebayAuctionParameters">
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'price'} className="ebayParameterLabel">
                  Cena
                </label>
                <FormInput
                  value={formData.price}
                  onChange={handleChange}
                  type="number"
                  name={'price'}
                  placeholder={'cena'}
                  className="ebayParameterInput"
                  error={errors.price}
                  disabled={false}
                />
              </div>
            </div>
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'quantity'} className="ebayParameterLabel">
                  Ilość
                </label>
                <FormInput
                  value={formData.quantity}
                  onChange={handleChange}
                  type="number"
                  name={'quantity'}
                  placeholder={'ilość'}
                  className="ebayParameterInput"
                  error={errors.quantity}
                  disabled={false}
                />
              </div>
            </div>
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'quantityLimitPerBuyer'} className="ebayParameterLabel">
                  Ilość na kupującego
                </label>
                <FormInput
                  value={formData.quantityLimitPerBuyer}
                  onChange={handleChange}
                  type="number"
                  name={'quantityLimitPerBuyer'}
                  placeholder={'ilość na osobe'}
                  className="ebayParameterInput"
                  error={errors.quantityLimitPerBuyer}
                  disabled={false}
                />
              </div>
            </div>
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'returnPolicyId'} className="ebayParameterLabel">
                  Warunki reklamacji
                </label>
                <FormSelect
                  value={formData.returnPolicyId}
                  onChange={handleChange}
                  options={userPolicies?.returnPolicies.map((option) => ({
                    label: option.name,
                    value: option.id,
                  }))}
                  name={'returnPolicyId'}
                  error={undefined}
                />
              </div>
            </div>
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'fulfillmentPolicyId'} className="ebayParameterLabel">
                  Polityka realizacji
                </label>
                <FormSelect
                  value={formData.fulfillmentPolicyId}
                  onChange={handleChange}
                  options={userPolicies?.fulfillmentPolicies.map((option) => ({
                    label: option.name,
                    value: option.id,
                  }))}
                  name={'fulfillmentPolicyId'}
                  error={undefined}
                />
              </div>
            </div>
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'paymentPolicyId'} className="ebayParameterLabel">
                  Polityka płatności
                </label>
                <FormSelect
                  value={formData.paymentPolicyId}
                  onChange={handleChange}
                  options={userPolicies?.paymentPolicies.map((option) => ({
                    label: option.name,
                    value: option.id,
                  }))}
                  name={'paymentPolicyId'}
                  error={undefined}
                />
              </div>
            </div>
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'locationKey'} className="ebayParameterLabel">
                  Klucz lokalizacji
                </label>
                <FormSelect
                  value={formData.locationKey}
                  onChange={handleChange}
                  options={userPolicies?.locationKeys.map((option) => ({
                    label: option.name,
                    value: option.id,
                  }))}
                  name={'locationKey'}
                  error={undefined}
                />
              </div>
            </div>
            <div className="ebayProductParameter">
              <div className="ebayParameterField">
                <label htmlFor={'description'} className="ebayParameterLabel">
                  Opis
                </label>
                <FormTextarea
                  value={formData.description}
                  onChange={handleChange}
                  name={'description'}
                  error={errors.description}
                />
              </div>
            </div>
          </div>
        )}

        <div className="addAuctionAllEbayButtons">
          <div className="addAuctionEbayBackButton">
            <BackButton onClick={onPrevPage} />
          </div>
          <div className="addAuctionEbayButtons">
            <CancelButton pathTo={''} onClick={onCancel} />
            <ConfrimButton />
          </div>
        </div>
      </form>
    </div>
  );
};

export default EbayListingDetails;
