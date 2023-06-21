import './css/categoryInput.css';

function CategoryInput() {
  return (
    <div className="categoryField">
      <label htmlFor="category" className="skuLabel">
        Kategoria
      </label>
      <input
        type="text"
        id="category"
        name="category"
        placeholder="Kategoria"
        className="categoryInput"
      ></input>
    </div>
  );
}

export default CategoryInput;
