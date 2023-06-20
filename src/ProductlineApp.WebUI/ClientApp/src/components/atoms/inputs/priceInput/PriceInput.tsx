import "./css/priceInput.css"

function PriceInput() {

    return (
        <div className="priceField">
            <label htmlFor="price" className="priceLabel">Cena</label>
            <input type="text" id="price" name="price" placeholder="Cena" className="priceInput"></input>
        </div>
    );
}

export default PriceInput