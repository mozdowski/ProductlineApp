import FormInput from '../../common/formInput/formInput';
import './css/brandInput.css';

function BrandInput({
  value,
  onChange,
  error,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
  error: any;
}) {
  return (
    <div className="brandField">
      <label htmlFor="sku" className="brandLabel">
        Marka
      </label>
      <FormInput
        value={value}
        onChange={onChange}
        type="text"
        id="brand"
        name="brand"
        placeholder="Marka"
        className="brandInput"
        error={error}
      />
    </div>
  );
}

export default BrandInput;
