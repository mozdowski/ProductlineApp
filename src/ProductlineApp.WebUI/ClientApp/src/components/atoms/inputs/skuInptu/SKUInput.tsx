import "./css/skuInput.css"

function SKUInput() {

    return (
        <div className="skuField">
            <label htmlFor="sku" className="skuLabel">SKU</label>
            <input type="text" id="sku" name="sku" placeholder="SKU" className="skuInput"></input>
        </div>
    );
}

export default SKUInput