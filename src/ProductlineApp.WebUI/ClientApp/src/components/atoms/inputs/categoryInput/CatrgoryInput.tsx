import FormInput from '../../common/formInput/formInput';
import './css/categoryInput.css';

function CategoryInput({
  value,
  onChange,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
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
      />
    </div>
  );
}

export default CategoryInput;
