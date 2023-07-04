import { ProductSKU } from '../../../../interfaces/products/getProductsSKU';
import { FormSelect } from '../../common/formSelect/formSelect';
import './css/selectProductInput.css';

function SelectProductInput({
  showFormSteps,
  productsSKURecords,
  value,
  onChange,
  error,
}: {
  showFormSteps: any;
  productsSKURecords: ProductSKU[];
  value: string;
  onChange: (name: string, value: string) => void;
  error: any;
}) {
  const options: { label: string; value: string }[] = [];
  for (const key in productsSKURecords) {
    if (isNaN(Number(key))) {
      const value = productsSKURecords[key];
      options.push({
        value: value.sku,
        label: value.sku,
      });
    }
  }

  return (
    <div className="selectProductInputField">
      <label htmlFor="selectProduct" className="selectProductLabel">
        Produkt
      </label>
      <FormSelect
        value={value}
        onChange={onChange}
        options={options}
        type="text"
        id="product"
        name="product"
        placeholder="Produkt"
        className="selectProductInput"
        error={error}
        showFormSteps={showFormSteps}
      />
    </div>
  );
}

export default SelectProductInput;
