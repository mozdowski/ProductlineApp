import { useEffect, useRef, useState } from 'react';
import {
  AllegroCatalogueProduct,
  Parameter,
} from '../../../../../../../interfaces/platforms/getAllegroCatalogueResponse';
import AllegroParameterInput from '../../../../../../atoms/inputs/allegroParameterInput/allegroParameterInput';
import { useAuctionsService } from '../../../../../../../hooks/auctions/useAuctionsService';
import {
  AllegroProductParameter,
  ParameterRestrictions,
} from '../../../../../../../interfaces/platforms/allegroProductParametersResponse';
import { toast } from 'react-toastify';
import * as Yup from 'yup';
import { CircularProgress } from '@mui/material';
import './parametersSetComponent.css';
import BackButton from '../../../../../../atoms/buttons/backButton/backButton';
import CancelButton from '../../../../../../atoms/buttons/cancelButton/CancelButton';
import NextButton from '../../../../../../atoms/buttons/nextButton/nextButton';

interface ParametersSetComponentProps {
  productId: string;
  categoryId: string;
  onPrevPage: () => void;
  onNextPage: () => void;
  onCancel: () => void;
}

export enum ParamType {
  INTEGER = 'integer',
  FLOAT = 'float',
  DICTIONARY = 'dictionary',
}

const generateValidationSchema = (restrictionsList: ParameterRestrictions[]): Yup.Schema<any> => {
  let schema = Yup.object();

  restrictionsList.forEach((restrictions) => {
    if (restrictions.min !== undefined) {
      schema = schema.shape({
        value: Yup.number().min(
          restrictions.min,
          `Wartość nie może być mniejsza niż ${restrictions.min}`,
        ),
      });
    }

    if (restrictions.max !== undefined) {
      schema = schema.shape({
        value: Yup.number().max(
          restrictions.max,
          `Wartość nie może być większa niż ${restrictions.max}`,
        ),
      });
    }

    if (restrictions.range) {
      schema = schema.shape({
        value: Yup.number().test('is-range', 'Wartość poza dozwolonym przedziałem', (value) => {
          const { min, max } = restrictions;
          if (!value) return false;
          return value >= min! && value <= max!;
        }),
      });
    }

    if (restrictions.precision !== undefined) {
      schema = schema.shape({
        value: Yup.number().test(
          'is-precision',
          'Wartość poza dozwoloną wartością precyzji',
          (value) => {
            const precisionFactor = Math.pow(10, restrictions.precision!);
            if (!value) return false;
            return Math.round(value * precisionFactor) / precisionFactor === value;
          },
        ),
      });
    }

    if (restrictions.minLength !== undefined) {
      schema = schema.shape({
        value: Yup.string().min(
          restrictions.minLength,
          `Wymagane co najmniej ${restrictions.minLength} znaków`,
        ),
      });
    }

    if (restrictions.maxLength !== undefined) {
      schema = schema.shape({
        value: Yup.string().max(
          restrictions.maxLength,
          `Wymagane co najwyżej ${restrictions.maxLength} znaków`,
        ),
      });
    }

    if (restrictions.allowedNumberOfValues !== undefined) {
      schema = schema.shape({
        value: Yup.array()
          .of(Yup.string())
          .test('is-allowed-number-of-values', 'Nieprawidłowa liczba wartości', (value) => {
            return Array.isArray(value) && value.length === restrictions.allowedNumberOfValues;
          }),
      });
    }

    // if (restrictions.multipleChoices) {
    //   schema = schema.shape({
    //     value: Yup.array()
    //       .of(Yup.string())
    //       .test('is-multiple-choices', 'Niewłaściwy wybór', (value) => {
    //         return Array.isArray(value) && value.length > 1;
    //       }),
    //   });
    // }
  });

  return schema;
};

const ParametersSetComponent: React.FC<ParametersSetComponentProps> = ({
  productId,
  categoryId,
  onPrevPage,
  onNextPage,
  onCancel,
}) => {
  const [formFields, setFormFields] = useState<{ [index: string]: any }>({});
  const [product, setProduct] = useState<AllegroCatalogueProduct>();
  const [parameters, setParameters] = useState<AllegroProductParameter[]>([]);
  const [commonParameters, setCommonParameters] = useState<AllegroProductParameter[]>([]);
  const [validationSchema, setValidationSchema] = useState<Yup.Schema<any>>();
  const { auctionsService } = useAuctionsService();
  const [errors, setErrors] = useState<Partial<{ [index: string]: any }>>({});
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const formRef = useRef(null);

  useEffect(() => {
    setIsLoading(true);
    const fetchData = async () => {
      try {
        const [product, parameters] = await Promise.all([
          auctionsService.getAllegoCatalogueProductDetails(productId),
          auctionsService.getAllegoParametersByCategory(categoryId),
        ]);
        setProduct(product);
        setParameters(parameters.parameters);

        const parametersSubset = createParametersSubset(parameters.parameters, product);
        setCommonParameters(parametersSubset);

        setValidationSchema(
          generateValidationSchema(commonParameters.map((param) => param.restrictions)),
        );

        initForm(parametersSubset, product);
        setIsLoading(false);
      } catch (error) {
        toast.error('Ups, coś poszło nie tak...');
      }
    };

    fetchData();
  }, []);

  const validateForm = async () => {
    if (!formRef) return true;
    if (!validationSchema) return true;
    try {
      await validationSchema.validate(formFields, { abortEarly: false });
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

  const createParametersSubset = (
    parametersSet: AllegroProductParameter[],
    productSet: AllegroCatalogueProduct,
  ) => {
    const commonElements = parametersSet.filter((param: AllegroProductParameter) =>
      productSet?.parameters.some((prodParam: Parameter) => param.id === prodParam.id),
    ) as AllegroProductParameter[];

    const additionalElements = parametersSet.filter(
      (param: AllegroProductParameter) => param.required,
    ) as AllegroProductParameter[];

    return [...commonElements, ...additionalElements];
  };

  const handleInputChange = (name: string, value: string | number | string[]) => {
    setFormFields((prevData) => ({
      ...prevData,
      [name]: value,
    }));
    console.log('=============');
    console.log(formFields);
    console.log(errors);
  };

  const initForm = (params: AllegroProductParameter[], productData: AllegroCatalogueProduct) => {
    params.forEach((param) => {
      const name = param.name;
      const value = getInputDefaultValue(
        param.id,
        param.type,
        productData,
        param.restrictions.multipleChoices,
      );
      console.log(name);
      console.log(value);
      setFormFields((prevData) => ({
        ...prevData,
        [name]: value,
      }));
    });
  };

  const getInputDefaultValue = (
    paramId: string,
    type: string,
    productData?: AllegroCatalogueProduct,
    isMultiselect?: boolean,
  ) => {
    const parameter = productData?.parameters.find((x) => x.id === paramId);
    if (!parameter) return '';
    switch (type as ParamType) {
      case ParamType.DICTIONARY: {
        if (isMultiselect) return parameter?.valuesLabels;
        else return parameter?.valuesIds;
      }
      default: {
        return parameter?.values[0];
      }
    }
  };

  return (
    <div className="allegroPopupBody">
      {isLoading && (
        <div className="loadingCircle">
          <CircularProgress />
        </div>
      )}
      <div className="allegroAuctionParameters">
        {commonParameters && commonParameters.length > 0 && !isLoading && (
          <>
            {commonParameters.map((parameter, index) => (
              <div key={index}>
                <AllegroParameterInput
                  id={parameter.id}
                  name={parameter.name}
                  type={parameter.type}
                  isMultiselect={parameter.restrictions?.multipleChoices}
                  options={parameter.dictionary?.map((item) => ({
                    label: item.value,
                    value: item.id,
                  }))}
                  unit={parameter?.unit}
                  value={getInputDefaultValue(
                    parameter.id,
                    parameter.type,
                    product,
                    parameter.restrictions.multipleChoices,
                  )}
                  onChange={handleInputChange}
                  error={errors[parameter.name]}
                />
              </div>
            ))}
          </>
        )}
      </div>
      <div className="addAuctionAllAllegroButtons">
        <div className="addAuctionAllegroBackButton">
          <BackButton onClick={onPrevPage} />
        </div>
        <div className="addauctionAllegroButtons">
          <CancelButton pathTo={''} close={onCancel} />
          <NextButton onClick={onNextPage} />
        </div>
      </div>
    </div>
  );
};

export default ParametersSetComponent;
