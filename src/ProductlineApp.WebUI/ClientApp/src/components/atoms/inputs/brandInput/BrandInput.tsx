import { isDisabled } from '@testing-library/user-event/dist/utils';
import FormInput from '../../common/formInput/formInput';
import './css/brandInput.css';

function BrandInput({
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
        disabled={disabled}
      />
    </div>
  );
}

export default BrandInput;
