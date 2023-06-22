import FormInput from '../../common/formInput/formInput';
import './css/productNameInput.css';

function PoductNameInput({
  value,
  onChange,
  error,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
  error: any;
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
      />
    </div>
  );
}

export default PoductNameInput;
