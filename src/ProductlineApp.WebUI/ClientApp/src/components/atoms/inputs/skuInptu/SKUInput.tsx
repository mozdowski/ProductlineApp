import FormInput from '../../common/formInput/formInput';
import './css/skuInput.css';

function SKUInput({
  value,
  onChange,
  error,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
  error: any;
}) {
  return (
    <div className="skuField">
      <label htmlFor="sku" className="skuLabel">
        SKU
      </label>
      <FormInput
        value={value}
        onChange={onChange}
        id="sku"
        name="sku"
        placeholder="SKU"
        className="skuInput"
        type="text"
        error={error}
      />
    </div>
  );
}

export default SKUInput;
