import "./css/conditionInput.css"

function ConditionInput() {

    return (
        <div className="conditionField">
            <label htmlFor="condition" className="conditionLabel">Stan</label>
            <input type="text" id="condition" name="condition" placeholder="Stan" className="conditionInput"></input>
        </div>
    );
}

export default ConditionInput