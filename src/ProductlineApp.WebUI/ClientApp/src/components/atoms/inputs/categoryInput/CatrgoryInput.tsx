import FormInput from '../../common/formInput/formInput';
import './css/categoryInput.css';

function CategoryInput({
  value,
  onChange,
  error,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
  error: any;
}) {
  return (
    <div className="categoryField">
      <label htmlFor="category" className="skuLabel">
        Kategoria
      </label>
      <FormInput
        value={value}
        onChange={onChange}
        type="text"
        id="category"
        name="category"
        placeholder="Kategoria"
        className="categoryInput"
        error={error}
      />
    </div>
  );
}

export default CategoryInput;
