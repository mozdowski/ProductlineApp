import FormInput from '../../common/formInput/formInput';
import './css/quantityInput.css';

function QuantityInput({
  value,
  onChange,
  error,
}: {
  value: number;
  onChange: (name: string, value: number) => void;
  error: any;
}) {
  return (
    <div className="quantityField">
      <label htmlFor="quantity" className="quantityLabel">
        Ilość
      </label>
      <FormInput
        value={value}
        onChange={onChange}
        type="text"
        id="quantity"
        name="quantity"
        placeholder="Ilość"
        className="quantityInput"
        error={error}
      />
    </div>
  );
}

export default QuantityInput;
