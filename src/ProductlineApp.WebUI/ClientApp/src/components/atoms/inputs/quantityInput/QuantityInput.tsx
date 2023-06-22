import FormInput from '../../common/formInput/formInput';
import './css/quantityInput.css';

function QuantityInput({
  value,
  onChange,
}: {
  value: number;
  onChange: (name: string, value: number) => void;
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
      />
    </div>
  );
}

export default QuantityInput;
