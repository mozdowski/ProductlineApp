import './css/impementedOrdersButton.css';

function ImpementedOrdersButton({ isSelectedTypeOrders, handleClickTypeOrdersButton, id }: { isSelectedTypeOrders: any, handleClickTypeOrdersButton: any, id: string }) {
    return (
        <div id={id} className={isSelectedTypeOrders === "implemented" ? "implementedOrdersButton selected" : "implementedOrdersButton"} onClick={handleClickTypeOrdersButton}>
            <p>Zrealizowane</p>
        </div>
    );
}

export default ImpementedOrdersButton