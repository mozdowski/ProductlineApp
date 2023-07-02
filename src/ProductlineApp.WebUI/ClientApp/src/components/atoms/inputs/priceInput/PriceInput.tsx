import FormInput from '../../common/formInput/formInput';
import './css/priceInput.css';

function PriceInput({
  value,
  onChange,
  error,
  disabled
}: {
  value: number;
  onChange: (name: string, value: number) => void;
  error: any;
  disabled: boolean
}) {
  return (
    <div className="priceField">
      <label htmlFor="price" className="priceLabel">
        Cena
      </label>
      <FormInput
        value={value}
        onChange={onChange}
        type="text"
        id="price"
        name="price"
        placeholder="Cena"
        className="priceInput"
        error={error}
        disabled={disabled}
      />
    </div>
  );
}

export default PriceInput;
