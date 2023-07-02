import { FormTextarea } from '../../common/formTextArea/formTextArea';
import './css/productDescriptionInput.css';

function ProductDescritionInput({
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
    <div className="productDescriptionField">
      <label htmlFor="productDescription" className="productDescriptionLabel">
        Opis produktu
      </label>
      <FormTextarea
        value={value}
        onChange={onChange}
        id="productDescription"
        name="description"
        placeholder="Opis produktu"
        className="productDescriptionTextarea"
        error={error}
        disabled={disabled}
      />
    </div>
  );
}

export default ProductDescritionInput;
