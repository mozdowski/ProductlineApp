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
  onNextPage: (data: any) => void;
  onCancel: () => void;
}

interface ValidationModel {
  name: string;
  type: string;
  restrictions: ParameterRestrictions;
}

export enum ParamType {
  INTEGER = 'integer',
  FLOAT = 'float',
  DICTIONARY = 'dictionary',
}

const generateValidationSchema = (validationModels: ValidationModel[]): Yup.Schema<any> => {
  const schemaObject: Record<string, Yup.AnySchema> = {};

  validationModels.forEach((validationModel, index) => {
    const { name, type, restrictions } = validationModel;

    const { min, max, range, precision, minLength, maxLength, allowedNumberOfValues } =
      restrictions;

    let fieldSchema = Yup.mixed();

    if (min !== undefined) {
      fieldSchema = fieldSchema.test(
        `min-${name}`,
        `Wartość  nie może być mniejsza niż ${min}`,
        (value: any) => (value as number) >= min,
      );
    }

    if (max !== undefined) {
      fieldSchema = fieldSchema.test(
        `max-${name}`,
        `Wartość nie może być większa niż ${max}`,
        (value: any) => (value as number) <= max,
      );
    }

    if (range && min && max) {
      fieldSchema = fieldSchema.test(
        `range-${name}`,
        `Wartość poza dozwolonym przedziałem`,
        (value: any) => (value as number) >= min && (value as number) <= max,
      );
    }

    if (precision !== undefined) {
      fieldSchema = fieldSchema.test(
        `precision-${name}`,
        `Wartość poza dozwoloną wartością precyzji`,
        (value: any) => {
          const regex = new RegExp(`^-?\\d+(\\.\\d{1,${precision}})?$`);
          return regex.test(value.toString());
        },
        // (value: any) => Math.round((value as number) * Math.pow(10, precision)) / Math.pow(10, precision) === value as number
      );
    }

    if (minLength !== undefined) {
      fieldSchema = fieldSchema.test(
        `minLength-${name}`,
        `Wymagane co najmniej ${minLength} znaków`,
        (value: any) => value.length >= minLength,
      );
    }

    if (maxLength !== undefined) {
      fieldSchema = fieldSchema.test(
        `maxLength-${name}`,
        `Wymagane co najwyżej ${maxLength} znaków`,
        (value: any) => value.length <= maxLength,
      );
    }

    if (allowedNumberOfValues !== undefined) {
      fieldSchema = fieldSchema.test(
        `allowedNumberOfValues-${name}`,
        `Nieprawidłowa liczba wartości`,
        (value) =>
          type === 'string' && (value as string).split(' ').length <= allowedNumberOfValues,
        // (value) => Array.isArray(value) && value.length === allowedNumberOfValues
      );
    }

    schemaObject[name] = fieldSchema;
  });

  const schema = Yup.object().shape(schemaObject);
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
          generateValidationSchema(
            parametersSubset.map((param: AllegroProductParameter) => {
              const validationModel: ValidationModel = {
                name: param.name,
                type: param.type,
                restrictions: param.restrictions,
              };
              return validationModel;
            }),
          ),
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
    if (!validationSchema) return false;
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
      (param: AllegroProductParameter) => param.required && !productSet.parameters.some(x => x.id === param.id),
    ) as AllegroProductParameter[];

    console.log(parametersSet);
    console.log(productSet);
    console.log(commonElements);
    console.log(additionalElements);

    return [...commonElements, ...additionalElements];
  };

  const handleInputChange = (name: string, value: string | number | string[]) => {
    setFormFields((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const initForm = (params: AllegroProductParameter[], productData: AllegroCatalogueProduct) => {
    params.forEach((param) => {
      const name = param.name;
      const value = getInputDefaultValue(
        param.id,
        param.name,
        param.type,
        productData,
        param.restrictions.multipleChoices,
      );
      setFormFields((prevData) => ({
        ...prevData,
        [name]: value,
      }));
    });
  };

  const getInputDefaultValue = (
    paramId: string,
    name: string,
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
        return formFields[name] !== undefined ? formFields[name] : parameter?.values[0];
      }
    }
  };

  const handleNextPage = async () => {
    const isValid = await validateForm();
    if (!isValid) return;

    console.log(formFields);

    onNextPage(Object.entries(formFields).map(([name, value]) => {
        return {
          name,
          valueIds: Array.isArray(value) ? value : [value.toString()]
        };
      }));
  };

  return (
    <div className="allegroPopupBody">
      {isLoading && (
        <div className="loadingCircle">
          <CircularProgress />
        </div>
      )}
              {commonParameters && commonParameters.length > 0 && !isLoading && (

      <div className="allegroAuctionParameters">
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
                    parameter.name,
                    parameter.type,
                    product,
                    parameter.restrictions.multipleChoices,
                  )}
                  onChange={handleInputChange}
                  error={errors[parameter.name]}
                />
              </div>
            ))}
      </div>
      )}

      <div className="addAuctionAllAllegroButtons">
        <div className="addAuctionAllegroBackButton">
          <BackButton onClick={onPrevPage} />
        </div>
        <div className="addauctionAllegroButtons">
          <CancelButton pathTo={''} close={onCancel} />
          <NextButton onClick={handleNextPage} />
        </div>
      </div>
    </div>
  );
};

export default ParametersSetComponent;
