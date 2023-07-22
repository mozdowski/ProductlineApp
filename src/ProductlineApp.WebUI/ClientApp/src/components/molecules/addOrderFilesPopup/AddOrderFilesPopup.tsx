import { useEffect, useRef, useState } from "react";
import DropFileInput from "../../atoms/inputs/dropFileInput/DropFileInput";
import "./css/addOrderFilesPopup.css"
function AddOrderFilesPopup() {
    return (
        <div className="addOrderFilesPopup">
            <div className="orderFilesPopup">
                <DropFileInput />
            </div>
        </div>
    )
}
export default AddOrderFilesPopup;