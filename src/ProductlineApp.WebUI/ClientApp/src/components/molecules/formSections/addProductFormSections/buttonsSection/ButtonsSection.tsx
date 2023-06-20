import CancelButton from "../../../../atoms/buttons/cancelButton/CancelButton";
import ConfrimButton from "../../../../atoms/buttons/confirmButton/ConfirmButton";
import "./css/buttonsSection.css"

function ButtonsSection() {
    return (
        <>
            <div className="addProductButtonsSection">
                <CancelButton />
                <ConfrimButton />
            </div>
        </>
    );
}

export default ButtonsSection