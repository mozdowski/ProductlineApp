import "./css/ProductsTable.css";
import { ProductsTableHeader } from "../../molecules/table/headers/ProductsTableHeader";
import { ProductsTableBody } from "../../molecules/table/bodys/ProductsTableBody";
import { TableFooter } from "../../molecules/table/footers/TableFooter";
import { ProductsHederActions } from "../../molecules/table/headersActions/ProductsHederActions";
import { ProductsRecord } from "../../../interfaces/products/ProductsPageInteface";



export default function ProductsTable({ productRecords }: { productRecords: ProductsRecord[] }) {

    return (
        <>
            <ProductsHederActions />
            <table className="products">
                <ProductsTableHeader />
                <ProductsTableBody productRecords={productRecords} />
            </table >
            <TableFooter />
        </>
    );
}

