import FormInput from '../../common/formInput/formInput';
import './css/priceInput.css';

function PriceInput({
  value,
  onChange,
}: {
  value: number;
  onChange: (name: string, value: number) => void;
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
      />
    </div>
  );
}

export default PriceInput;
