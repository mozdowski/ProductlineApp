import FormInput from '../../common/formInput/formInput';
import './css/conditionInput.css';

function ConditionInput({
  value,
  onChange,
  error,
  disabled
}: {
  value: string;
  onChange: (name: string, value: string) => void;
  error: any;
  disabled: boolean
}) {
  return (
    <div className="conditionField">
      <label htmlFor="condition" className="conditionLabel">
        Stan
      </label>
      <FormInput
        value={value}
        onChange={onChange}
        type="text"
        id="condition"
        name="condition"
        placeholder="Stan"
        className="conditionInput"
        error={error}
        disabled={disabled}
      />
    </div>
  );
}

export default ConditionInput;
