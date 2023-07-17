import './ebayParametersSetComponent.css';
import { useEffect, useState } from 'react';
import { useAuctionsService } from '../../../../../../../hooks/auctions/useAuctionsService';
import CancelButton from '../../../../../../atoms/buttons/cancelButton/CancelButton';
import NextButton from '../../../../../../atoms/buttons/nextButton/nextButton';
import { EbayCategoryAspect } from '../../../../../../../interfaces/auctions/ebayCategoryAspectsResponse';
import * as Yup from 'yup';
import { FormSelect } from '../../../../../../atoms/common/formSelect/formSelect';
import { CircularProgress } from '@mui/material';
import BackButton from '../../../../../../atoms/buttons/backButton/backButton';
import AutocompleteComboBox from '../../../../../../atoms/common/autocomplete/autocomplete';
import MultipleSelectCheckmarks from '../../../../../../atoms/common/multiselect/multiselect';

interface EbayParametersSetComponentProps {
  categoryId: string;
  onCancel: () => void;
  onNext: (data: Record<string, string[]>) => void;
  onPrev: () => void;
  initAspects?: Record<string, string[]>;
}

enum EbayAspectMode {
  FREE_TEXT = 'FREE_TEXT',
  SELECTION_ONLY = 'SELECTION_ONLY',
}

const EbayParametersSetComponent: React.FC<EbayParametersSetComponentProps> = ({
  categoryId,
  onCancel,
  onNext,
  onPrev,
  initAspects,
}) => {
  const { auctionsService } = useAuctionsService();
  const [categoryAspects, setCategoryAspects] = useState<EbayCategoryAspect[]>([]);
  const [parametersForm, setParametersForm] = useState<{ [index: string]: any }>({});
  const [errors, setErrors] = useState<Partial<typeof parametersForm>>({});
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [validationSchema, setValidationSchema] = useState<Yup.ObjectSchema<any> | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      setIsLoading(true);
      const aspectsResponse = await auctionsService.getEbayCategoryAspects(categoryId);
      setCategoryAspects(aspectsResponse.platformAspects);
      initForm(aspectsResponse.platformAspects);
      setIsLoading(false);
    };

    fetchData();
  }, []);

  const initForm = (aspects: EbayCategoryAspect[]) => {
    const schemaObject: Record<string, Yup.AnySchema> = {};

    aspects.forEach((x) => {
      const mode = x.mode as EbayAspectMode;
      const value = x.isRequired && mode === EbayAspectMode.SELECTION_ONLY ? '0' : '';
      setParametersForm((prev) => ({
        ...prev,
        [x.name]: initAspects ? initAspects[x.name] : value,
      }));

      if (x.isRequired) {
        const fieldSchema = Yup.mixed().test(
          `is-required-${x.name}`,
          'Wartość wymagana',
          (value) => value !== '',
        );
        schemaObject[x.name] = fieldSchema;
      }
    });

    setValidationSchema(Yup.object().shape(schemaObject));
  };

  const validateForm = async () => {
    if (!validationSchema) return true;
    try {
      await validationSchema.validate(parametersForm, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<{ [index: string]: any }> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof { [index: string]: any }] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  const handleChange = (name: string, value: string | string[]) => {
    if (!name || !value) return;

    setParametersForm((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const prepareAspectsForRequest = (): Record<string, any> => {
    const filteredObj: Record<string, string[]> = {};

    categoryAspects.forEach((x) => {
      if (parametersForm[x.name]) {
        const value = parametersForm[x.name];
        const values = Array.isArray(value) ? value : [value];

        filteredObj[x.name] =
          (x.mode as EbayAspectMode) === EbayAspectMode.FREE_TEXT
            ? values
            : values.map((index) => x.values[index]);
      }
    });

    return filteredObj;
  };

  const handleNext = async () => {
    const isValid = await validateForm();
    if (!isValid) return;

    const aspects = prepareAspectsForRequest();

    onNext(aspects);
  };

  const renderComponentForAspect = (aspect: EbayCategoryAspect) => {
    const mode = aspect.mode as EbayAspectMode;

    if (mode === EbayAspectMode.FREE_TEXT) {
      return (
        <AutocompleteComboBox
          value={parametersForm[aspect.name]}
          onChange={handleChange}
          placeholder={aspect.name}
          options={aspect.values.map((option, index) => ({
            label: option,
            value: index,
          }))}
          name={aspect.name}
          error={errors[aspect.name]}
        />
      );
    } else {
      if (aspect.isSingleValue) {
        return (
          <FormSelect
            value={parametersForm[aspect.name]}
            onChange={handleChange}
            options={aspect.values.map((option, index) => ({
              label: option,
              value: index,
            }))}
            name={aspect.name}
            error={errors[aspect.name]}
          />
        );
      } else {
        <MultipleSelectCheckmarks
          value={parametersForm[aspect.name]}
          onChange={handleChange}
          options={aspect.values.map((option, index) => ({
            label: option,
            value: index,
          }))}
          name={aspect.name}
          error={errors[aspect.name]}
        />;
      }
    }
  };

  return (
    <div className="ebayPopupBody">
      {isLoading && (
        <div className="loadingCircle">
          <CircularProgress />
        </div>
      )}
      {categoryAspects && categoryAspects.length > 0 && !isLoading && (
        <div className="ebayAuctionParameters">
          {categoryAspects.map((aspect, index) => (
            <div className="ebayProductParameter" key={index}>
              <label htmlFor={aspect.name} className="ebayParameterLabel">
                {aspect.name}
              </label>
              {renderComponentForAspect(aspect)}
            </div>
          ))}
        </div>
      )}
      <div className="addAuctionAllEbayButtons">
        <div className="addAuctionEbayBackButton">
          {!initAspects && <BackButton onClick={onPrev} />}
        </div>
        <div className="addAuctionEbayButtons">
          <CancelButton onClick={onCancel} />
          <NextButton onClick={handleNext} />
        </div>
      </div>
    </div>
  );
};

export default EbayParametersSetComponent;
