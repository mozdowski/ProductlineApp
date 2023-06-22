import FormInput from '../../common/formInput/formInput';
import './css/skuInput.css';

function SKUInput({
  value,
  onChange,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
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
      />
    </div>
  );
}

export default SKUInput;
