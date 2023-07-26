import CancelButton from '../../../../../../atoms/buttons/cancelButton/CancelButton';
import { useEffect, useState } from 'react';
import BackButton from '../../../../../../atoms/buttons/backButton/backButton';
import * as Yup from 'yup';
import { AllegroDurationPeriods } from '../../../../../../../interfaces/auctions/createAllegroAuction';
import { CircularProgress } from '@mui/material';
import FormInput from '../../../../../../atoms/common/formInput/formInput';
import { FormSelect } from '../../../../../../atoms/common/formSelect/formSelect';
import { useAuctionsService } from '../../../../../../../hooks/auctions/useAuctionsService';
import { AllegroUserPoliciesResponse } from '../../../../../../../interfaces/auctions/allegroUserPoliciesResponse';
import './allegroListingDetails.css';
import ConfrimButton from '../../../../../../atoms/buttons/confirmButton/ConfirmButton';
import { useSelectedProduct } from '../../../../../../../hooks/auctions/useSelectedProduct';
import { AllegroOfferProductDetailsResponse } from '../../../../../../../interfaces/auctions/allegroOfferProductDetailsResponse';
import { FormTextarea } from '../../../../../../atoms/common/formTextArea/formTextArea';

export interface AllegroListingDetailsFormData {
  name: string;
  impliedWarrantyId: string;
  returnPolicyId: string;
  price: number;
  locationCity: string;
  locationCountryCode: string;
  locationPostCode: string;
  locationProvince: string;
  duration: AllegroDurationPeriods;
  republish: boolean;
  shippingRateId: string;
  quantity: number;
  description: string;
}

const getDurationLabel = (duration: AllegroDurationPeriods): string => {
  switch (duration) {
    case AllegroDurationPeriods.PT24H:
      return '24 godziny';
    case AllegroDurationPeriods.P2D:
      return '2 dni';
    case AllegroDurationPeriods.P3D:
      return '3 dni';
    case AllegroDurationPeriods.P4D:
      return '4 dni';
    case AllegroDurationPeriods.P5D:
      return '5 dni';
    case AllegroDurationPeriods.P7D:
      return '7 dni';
    case AllegroDurationPeriods.P10D:
      return '10 dni';
    case AllegroDurationPeriods.P14D:
      return '14 dni';
    case AllegroDurationPeriods.P21D:
      return '21 dni';
    case AllegroDurationPeriods.P30D:
      return '30 dni';
    case AllegroDurationPeriods.P60D:
      return '60 dni';
    default:
      return '';
  }
};

interface AllegroListingDetailsProps {
  onPrevPage: () => void;
  onConfirm: (formData: AllegroListingDetailsFormData) => void;
  onCancel: () => void;
  initValues?: AllegroOfferProductDetailsResponse;
}

const AllegroListingDetails: React.FC<AllegroListingDetailsProps> = ({
  onPrevPage,
  onConfirm,
  onCancel,
  initValues,
}) => {
  const product = {
    name: '',
    price: 0,
    quantity: 0,
    description: '',
  };

  if (initValues) {
    product.name = initValues.name;
    product.price = initValues.price;
    product.quantity = initValues.quantity;
    product.description = initValues.description;
  } else {
    const { selectedProduct } = useSelectedProduct();
    product.name = selectedProduct.name;
    product.price = selectedProduct.price;
    product.description = selectedProduct.description;
  }

  const parser = new DOMParser();

  const [formData, setFormData] = useState<AllegroListingDetailsFormData>({
    name: initValues ? initValues.name : product.name,
    impliedWarrantyId: initValues ? initValues.impliedWarrantyId : '',
    returnPolicyId: initValues ? initValues.returnPolicyId : '',
    price: initValues ? initValues.price : product.price,
    locationCity: initValues ? initValues.location.city : '',
    locationCountryCode: initValues ? initValues.location.countryCode : 'PL',
    locationPostCode: initValues ? initValues.location.postCode : '',
    locationProvince: initValues ? initValues.location.province : 'MAZOWIECKIE',
    duration: initValues ? initValues.duration : AllegroDurationPeriods.P10D,
    republish: initValues ? initValues.republish : true,
    shippingRateId: initValues ? initValues.shippingRateId : '',
    quantity: initValues ? initValues.quantity : product.quantity,
    description: parser.parseFromString(
      initValues ? initValues.description : product.description,
      'text/html',
    ).body.textContent as string,
  });
  const [errors, setErrors] = useState<Partial<AllegroListingDetailsFormData>>({});
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [userPolicies, setUserPolicies] = useState<AllegroUserPoliciesResponse>({
    impliesWarranties: [],
    retunPolicies: [],
    shippingRates: [],
  });

  const { auctionsService } = useAuctionsService();

  const durations = Object.values(AllegroDurationPeriods).filter(
    (value) => typeof value === 'number',
  ) as number[];

  useEffect(() => {
    setIsLoading(true);
    auctionsService.getAllegoUserPolicies().then((res) => {
      setUserPolicies(res);
      setFormData((prev) => ({
        ...prev,
        impliedWarrantyId: res.impliesWarranties[0].id,
        shippingRateId: res.shippingRates[0].id,
        returnPolicyId: res.retunPolicies[0].id,
      }));
      setIsLoading(false);
    });
  }, []);

  const validationSchema = Yup.object().shape({
    name: Yup.string().required('Nazwa jest wymagana'),
    impliedWarrantyId: Yup.string().required('Pole wymagane'),
    returnPolicyId: Yup.string().required('Pole wymagane'),
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
    locationCity: Yup.string().required('Pole wymagane'),
    locationCountryCode: Yup.string().required('Pole wymagane'),
    locationPostCode: Yup.string().required('Pole wymagane'),
    locationProvince: Yup.string().required('Pole wymagane'),
    duration: Yup.string().required('Pole wymagane'),
    republish: Yup.string().required('Pole wymagane'),
    shippingRateId: Yup.string().required('Pole wymagane'),
    quantity: Yup.number()
      .typeError('Nieprawidłowy format')
      .integer()
      .required('Pole wymagane')
      .positive('Wartość musi być większa od 0'),
    //   .max(product.quantity, 'Wartość większa niz zdefiniowana dla produktu'),
    description: Yup.string().required('Pole wymagane'),
  });

  const validateForm = async () => {
    if (!validationSchema) return false;
    try {
      await validationSchema.validate(formData, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<AllegroListingDetailsFormData> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof AllegroListingDetailsFormData] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const isValid = await validateForm();
    if (!isValid) return;

    onConfirm(formData);
  };

  const handleChange = (name: string, value: any) => {
    if (name == 'republish') {
      value = value === '0';
    }

    if (name == 'duration') {
      value = parseInt(value) as AllegroDurationPeriods;
    }

    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  return (
    <div className="allegroPopupBody">
      <form onSubmit={handleSubmit}>
        {isLoading && (
          <div className="loadingCircle">
            <CircularProgress sx={{ alignSelf: 'center', color: 'var(--first-color)' }} />
          </div>
        )}
        {!isLoading && (
          <div className="allegroAuctionParameters">
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'title'} className="allegroParameterLabel">
                  Tytuł aukcji
                </label>
                <FormInput
                  value={formData.name}
                  onChange={handleChange}
                  type="text"
                  name={'name'}
                  placeholder={'nazwa'}
                  className="allegroParameterInput"
                  error={errors.name}
                  disabled={false}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'price'} className="allegroParameterLabel">
                  Cena
                </label>
                <FormInput
                  value={formData.price}
                  onChange={handleChange}
                  type="number"
                  name={'price'}
                  placeholder={'cena'}
                  className="allegroParameterInput"
                  error={errors.price}
                  disabled={false}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'locationCity'} className="allegroParameterLabel">
                  Miasto
                </label>
                <FormInput
                  value={formData.locationCity}
                  onChange={handleChange}
                  type="text"
                  name={'locationCity'}
                  placeholder={'miasto'}
                  className="allegroParameterInput"
                  error={errors.locationCity}
                  disabled={false}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'locationCountryCode'} className="allegroParameterLabel">
                  Kod kraju
                </label>
                <FormInput
                  value={formData.locationCountryCode}
                  onChange={handleChange}
                  type="text"
                  name={'locationCountryCode'}
                  placeholder={'kod kraju'}
                  className="allegroParameterInput"
                  error={errors.locationCountryCode}
                  disabled={false}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'locationPostCode'} className="allegroParameterLabel">
                  Kod pocztowy
                </label>
                <FormInput
                  value={formData.locationPostCode}
                  onChange={handleChange}
                  type="text"
                  name={'locationPostCode'}
                  placeholder={'kod pocztowy'}
                  className="allegroParameterInput"
                  error={errors.locationPostCode}
                  disabled={false}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'locationProvince'} className="allegroParameterLabel">
                  Region
                </label>
                <FormInput
                  value={formData.locationProvince}
                  onChange={handleChange}
                  type="text"
                  name={'locationProvince'}
                  placeholder={'region'}
                  className="allegroParameterInput"
                  error={errors.locationProvince}
                  disabled={false}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'quantity'} className="allegroParameterLabel">
                  Ilość
                </label>
                <FormInput
                  value={formData.quantity}
                  onChange={handleChange}
                  type="number"
                  name={'quantity'}
                  placeholder={'ilość'}
                  className="allegroParameterInput"
                  error={errors.quantity}
                  disabled={false}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'republish'} className="allegroParameterLabel">
                  Ponowne wystawianie
                </label>
                <FormSelect
                  value={Number(formData.republish).toString()}
                  onChange={handleChange}
                  options={[
                    { label: 'nie', value: '0' },
                    { label: 'tak', value: '1' },
                  ]}
                  name={'republish'}
                  error={undefined}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'impliedWarrantyId'} className="allegroParameterLabel">
                  Warunki reklamacji
                </label>
                <FormSelect
                  value={formData.impliedWarrantyId}
                  onChange={handleChange}
                  options={userPolicies?.impliesWarranties.map((option) => ({
                    label: option.name,
                    value: option.id,
                  }))}
                  name={'impliedWarrantyId'}
                  error={undefined}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'returnPolicyId'} className="allegroParameterLabel">
                  Polityka zwrotu
                </label>
                <FormSelect
                  value={formData.returnPolicyId}
                  onChange={handleChange}
                  options={userPolicies?.retunPolicies.map((option) => ({
                    label: option.name,
                    value: option.id,
                  }))}
                  name={'returnPolicyId'}
                  error={undefined}
                />
              </div>
            </div>
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'shippingRateId'} className="allegroParameterLabel">
                  Cennik dostaw
                </label>
                <FormSelect
                  value={formData.shippingRateId}
                  onChange={handleChange}
                  options={userPolicies?.shippingRates.map((option) => ({
                    label: option.name,
                    value: option.id,
                  }))}
                  name={'shippingRateId'}
                  error={undefined}
                />
              </div>
            </div>
            {!initValues && (
              <div className="allegroProductParameter">
                <div className="allegroParameterField">
                  <label htmlFor={'duration'} className="allegroParameterLabel">
                    Czas trwania
                  </label>
                  <FormSelect
                    value={formData.duration.valueOf().toString()}
                    onChange={handleChange}
                    options={durations.map((option) => ({
                      label: getDurationLabel(option),
                      value: option.toString(),
                    }))}
                    name={'duration'}
                    error={undefined}
                  />
                </div>
              </div>
            )}
            <div className="allegroProductParameter">
              <div className="allegroParameterField">
                <label htmlFor={'description'} className="allegroParameterLabel">
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

        <div className="addAuctionAllAllegroButtons">
          <div className="addAuctionAllegroBackButton">
            <BackButton onClick={onPrevPage} />
          </div>
          <div className="addauctionAllegroButtons">
            <CancelButton pathTo={''} onClick={onCancel} />
            <ConfrimButton />
          </div>
        </div>
      </form>
    </div>
  );
};

export default AllegroListingDetails;
