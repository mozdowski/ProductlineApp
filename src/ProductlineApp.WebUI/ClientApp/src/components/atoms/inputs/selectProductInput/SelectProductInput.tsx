import { ProductAuctionData } from '../../../../interfaces/products/getProductsSKU';
import { FormSelect } from '../../common/formSelect/formSelect';
import './css/selectProductInput.css';

function SelectProductInput({
  showFormSteps,
  products,
  value,
  onChange,
  error,
}: {
  showFormSteps: any;
  products: ProductAuctionData[];
  value: string | undefined;
  onChange: (name: string, value: string) => void;
  error: any;
}) {
  return (
    <div className="selectProductInputField">
      <label htmlFor="selectProduct" className="selectProductLabel">
        Produkt
      </label>
      <FormSelect
        value={value}
        onChange={onChange}
        options={products.map((product) => ({
          label: product.sku,
          value: product.id,
        }))}
        name="product"
        error={error}
      />
    </div>
  );
}

export default SelectProductInput;
