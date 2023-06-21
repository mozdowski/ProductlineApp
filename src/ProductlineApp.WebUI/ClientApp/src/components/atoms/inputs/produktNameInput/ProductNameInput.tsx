import './css/productNameInput.css';

function PoductNameInput() {
  return (
    <div className="productNameField">
      <label htmlFor="productName" className="productNameLabel">
        Nazwa produktu
      </label>
      <input
        type="text"
        id="productName"
        name="productName"
        placeholder="Nazwa produktu"
        className="productNameInput"
      ></input>
    </div>
  );
}

export default PoductNameInput;
