import React, { useEffect, useLayoutEffect, useRef, useState } from 'react';
import ProductsTemplate from '../components/templates/ProductsTemplate';
import { useProductsService } from '../hooks/products/useProductsService';
import { ProductsRecord } from '../interfaces/products/ProductsPageInteface';
import { mapProductConditionToString } from '../helpers/mappers';
import { Outlet } from 'react-router-dom';

export default function Products() {
  const ref = useRef<HTMLInputElement>(null);
  const { productsService } = useProductsService();
  const [height, setHeight] = useState(0);
  const [products, setProducts] = useState<ProductsRecord[]>([]);

  useEffect(() => {
    productsService.getProductList().then((res) => {
      const productsRecords = res.products.map((product) => ({
        sku: product.sku,
        brand: product.brand,
        productName: product.name,
        category: product.category,
        price: product.price,
        imageUrl: product.imageUrl,
        quantity: product.quantity,
        condition: mapProductConditionToString(product.condition),
        listingStatus: product.platforms.length > 0 ? 'Wystawione' : 'Niewystawione',
        isListed: product.platforms.length > 0,
        galleryUrls: product.gallery,
        platforms: product.platforms,
      }));
      setProducts(productsRecords);
    });
  }, []);

  useLayoutEffect(() => {
    if (ref.current != null) {
      setHeight(ref.current.clientHeight);
    }
  }, []);

  return (
    <>
      <Outlet />
      <ProductsTemplate productRecords={products} />
    </>
  );
}
