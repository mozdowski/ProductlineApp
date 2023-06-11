import React from "react";
import AddIcon from "../../../../assets/icons/add_icon.png";
import { Link } from "react-router-dom";
import './css/AddProductButton2.css';

function AddProductButton2() {
    return (
        <Link to="/products/add" className="addProductLink" id="link">
            <div className="addProductButton2">
                <img id="image2" src={AddIcon} />
                <p>Dodaj Produkt</p>
            </div>
        </Link>
    );
}

export default AddProductButton2