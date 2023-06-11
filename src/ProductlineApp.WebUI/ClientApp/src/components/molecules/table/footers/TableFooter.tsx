import React from "react"
import "./css/TableFooter.css"

export const TableFooter = () => {

    return (
        <div className="paginationTable">
            <ul className="pagination">
                <li>
                    <div className="nextButton activePage">
                        <p>1</p>
                    </div>
                </li>
                <li>
                    <div className="nextButton">
                        <p>2</p>
                    </div>
                </li>
                <li>
                    <div className="nextButton">
                        <p>3</p>
                    </div>
                </li>
            </ul>
        </div >
    )
}