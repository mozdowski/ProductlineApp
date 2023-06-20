import "./css/quantityInput.css"

function QuantityInput() {

    return (
        <div className="quantityField">
            <label htmlFor="quantity" className="quantityLabel">Ilość</label>
            <input type="text" id="quantity" name="quantity" placeholder="Ilość" className="quantityInput"></input>
        </div>
    );
}

export default QuantityInput