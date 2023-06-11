import './css/ProductsTemplate.css';
import ProductsTable from "../organisms/tables/ProductsTable";
import { ProductsRecord } from "../../interfaces/products/ProductsPageInteface";
import ProductsPageHeader from "../organisms/pageHeaders/ProductsPageHeader";

export default function ProductsTemplate({ productRecords }: { productRecords: ProductsRecord[] }) {
    return (
        <>
            <ProductsPageHeader />
            <div className="content">
                <div className="tableProducts">
                    <ProductsTable productRecords={productRecords} />
                </div>
            </div>
        </>
    );
}