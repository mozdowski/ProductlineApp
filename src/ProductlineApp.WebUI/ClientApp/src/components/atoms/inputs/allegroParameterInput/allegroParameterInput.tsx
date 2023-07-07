import { ParamType } from '../../../molecules/formSections/addAuctionFormSections/popups/allegro/parametersSetComponent/parametersSetComponent';
import FormInput from '../../common/formInput/formInput';
import { FormSelect } from '../../common/formSelect/formSelect';
import MultipleSelectCheckmarks from '../../common/multiselect/multiselect';
import './allegroParameterInput.css';

interface AllegroParameterInput {
  id: string;
  name: string;
  type: string;
  isMultiselect?: boolean;
  options?: { label: string; value: string }[];
  unit?: string;
  value: any;
  onChange: (name: string, value: any) => void;
  error: any;
}

const AllegroParameterInput: React.FC<AllegroParameterInput> = ({
  id,
  name,
  type,
  isMultiselect,
  options,
  unit,
  value,
  onChange,
  error,
}) => {
  const unitLabel = unit ? '[' + unit + ']' : '';
  const paramType = type as ParamType;

  if (paramType === ParamType.DICTIONARY && options) {
    if (isMultiselect) {
      return (
        <div className="allegroProductParameter" key={id}>
          <div className="allegroParameterField">
            <label htmlFor={name} className="allegroParameterLabel">
              {name}
            </label>
            <MultipleSelectCheckmarks
              value={value}
              onChange={onChange}
              options={options}
              id={id}
              name={name}
              placeholder={name}
              className="allegroParameterInput"
              error={error}
            />
          </div>
        </div>
      );
    } else {
      return (
        <div className="allegroProductParameter" key={id}>
          <div className="allegroParameterField">
            <label htmlFor={name} className="allegroParameterLabel">
              {name}
            </label>
            <FormSelect
              value={value[0]}
              onChange={onChange}
              options={options}
              name={name}
              error={error}
            />
          </div>
        </div>
      );
    }
  } else {
    return (
      <div className="allegroProductParameter" key={id}>
        <div className="allegroParameterField">
          <label htmlFor={name} className="allegroParameterLabel">
            {name + ' ' + unitLabel}
          </label>
          <FormInput
            value={value}
            onChange={onChange}
            type="text"
            id={id}
            name={name}
            placeholder={name}
            className="allegroParameterInput"
            error={error}
            disabled={false}
          />
        </div>
      </div>
    );
  }
};

export default AllegroParameterInput;
