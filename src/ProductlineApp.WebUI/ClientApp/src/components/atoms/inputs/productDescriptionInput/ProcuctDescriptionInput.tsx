import './css/productDescriptionInput.css';

function ProductDescritionInput() {
  return (
    <div className="productDescriptionField">
      <label htmlFor="productDescription" className="productDescriptionLabel">
        Opis produktu
      </label>
      <textarea
        id="productDescription"
        name="productDescription"
        placeholder="Opis produktu"
        className="productDescriptionTextarea"
      ></textarea>
    </div>
  );
}

export default ProductDescritionInput;
