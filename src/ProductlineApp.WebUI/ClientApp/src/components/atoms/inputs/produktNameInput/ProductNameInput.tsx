import FormInput from '../../common/formInput/formInput';
import './css/productNameInput.css';

function PoductNameInput({
  value,
  onChange,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
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
      />
    </div>
  );
}

export default PoductNameInput;
