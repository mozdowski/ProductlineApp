import FormInput from '../../common/formInput/formInput';
import './css/productNameInput.css';

function PoductNameInput({
  value,
  onChange,
  error,
  disabled,
}: {
  value: string | undefined;
  onChange: (name: string, value: string) => void;
  error: any;
  disabled: boolean;
}) {
  return (
    <div className="productNameField">
      <label htmlFor="productName" className="productNameLabel">
        Nazwa produktu
      </label>
      <FormInput
        value={value}
        onChange={onChange}
        type="text"
        id="productName"
        name="name"
        placeholder="Nazwa produktu"
        className="productNameInput"
        error={error}
        disabled={disabled}
      />
    </div>
  );
}

export default PoductNameInput;
