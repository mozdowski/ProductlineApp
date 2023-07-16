import './ebayFormPopup.css';
import { useEffect, useState } from 'react';
import { useAuctionsService } from '../../../../../../../hooks/auctions/useAuctionsService';
import CancelButton from '../../../../../../atoms/buttons/cancelButton/CancelButton';
import NextButton from '../../../../../../atoms/buttons/nextButton/nextButton';
import { EbayCategoryAspect } from '../../../../../../../interfaces/auctions/ebayCategoryAspectsResponse';
import * as Yup from 'yup';

interface EbayParametersSetComponentProps {
  categoryId: string;
  onCancel: () => void;
  onNext: () => void;
}

const EbayParametersSetComponent: React.FC<EbayParametersSetComponentProps> = ({
  categoryId,
  onCancel,
  onNext,
}) => {
  const { auctionsService } = useAuctionsService();
  const [categoryAspects, setCategoryAspects] = useState<EbayCategoryAspect[]>([]);
  const [parametersFrom, setParametersForm] = useState<{ [index: string]: any }>({});
  const [errors, setErrors] = useState<Partial<typeof parametersFrom>>({});
  let validationSchema: any;

  useEffect(() => {
    const fetchData = async () => {
      var aspectsResponse = await auctionsService.getEbayCategoryAspects(categoryId);
      setCategoryAspects(aspectsResponse.platformAspects);
      initForm(aspectsResponse.platformAspects);
    };

    fetchData();
  }, []);

  const initForm = (aspects: EbayCategoryAspect[]) => {
    let schemaObject: Record<string, Yup.AnySchema> = {};

    aspects.forEach((x) => {
      const value = x.isRequired ? x.values[0] : '';
      setParametersForm((prev) => ({
        ...prev,
        [x.name]: value,
      }));

      if (x.isRequired) {
        const fieldSchema = Yup.mixed().test(
          `is-required`,
          'Wartość wymagana',
          (value) => value !== '',
        );
        schemaObject[x.name] = fieldSchema;
      }
    });

    validationSchema = Yup.object().shape(schemaObject);
  };

  const validateForm = async () => {
    if (!validationSchema) return false;
    try {
      await validationSchema.validate(parametersFrom, { abortEarly: false });
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

  const handleChange = (name: string, value: string) => {
    if (!name || !value) return;

    setParametersForm((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleNext = async () => {
    const isValid = await validateForm();
    if (!isValid) return;

    onNext(); // TODO
  };

  return (
    <div className="ebayPopupBody">
      {categoryAspects.length > 0 && (
        <div>tutaj przeiterowac po categoryAspects i dla kazdego wygenerowac SelectForm</div>
      )}
      <div className="addAuctionAllEbayButtons">
        <div className="addAuctionEbayBackButton"></div>
        <div className="addAuctionEbayButtons">
          <CancelButton onClick={onCancel} />
          <NextButton onClick={handleNext} />
        </div>
      </div>
    </div>
  );
};

export default EbayParametersSetComponent;
