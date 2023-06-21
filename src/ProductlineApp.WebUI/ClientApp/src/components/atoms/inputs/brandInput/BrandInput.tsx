import './css/brandInput.css';

function BrandInput() {
  return (
    <div className="brandField">
      <label htmlFor="sku" className="brandLabel">
        Marka
      </label>
      <input type="text" id="brand" name="brand" placeholder="Marka" className="brandInput"></input>
    </div>
  );
}

export default BrandInput;
