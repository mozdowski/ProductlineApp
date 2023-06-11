import React, { useLayoutEffect, useRef, useState } from "react";
import ProductsTemplate from "../components/templates/ProductsTemplate";


export default function Products() {
    const ref = useRef<HTMLInputElement>(null);

    const [height, setHeight] = useState(0);

    useLayoutEffect(() => {
        if (ref.current != null) {
            setHeight(ref.current.clientHeight);
        }
    }, []);
    const countRows = Math.round((height - (65 + 49 + 61)) / 64);
    console.log("height " + height);
    console.log("liczba wierszy " + countRows)



    return (
        <ProductsTemplate productRecords={[]} />
    );
}