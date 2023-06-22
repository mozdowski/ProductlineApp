import { ProductCondition } from '../../../../enums/productCondition';
import FormInput from '../../common/formInput/formInput';
import { FormSelect } from '../../common/formSelect/formSelect';
import './css/conditionInput.css';

function ConditionInput({
  value,
  onChange,
}: {
  value: number;
  onChange: (name: string, value: string) => void;
}) {
  const options: { label: string; value: string }[] = [];
  for (const key in ProductCondition) {
    if (isNaN(Number(key))) {
      const value = ProductCondition[key];
      options.push({ value: value, label: key });
    }
  }

  return (
    <div className="conditionField">
      <label htmlFor="condition" className="conditionLabel">
        Stan
      </label>
      <FormSelect
        value={value.toString()}
        onChange={onChange}
        options={options}
        type="text"
        id="condition"
        name="condition"
        placeholder="Stan"
        className="conditionInput"
      />
    </div>
  );
}

export default ConditionInput;
