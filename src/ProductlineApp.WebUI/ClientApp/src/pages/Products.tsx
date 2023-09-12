import React, { useEffect, useLayoutEffect, useRef, useState } from 'react';
import ProductsTemplate from '../components/templates/ProductsTemplate';
import { useProductsService } from '../hooks/products/useProductsService';
import { ProductsRecord } from '../interfaces/products/ProductsPageInteface';
import { mapProductConditionToString } from '../helpers/mappers';
import { Outlet } from 'react-router-dom';
import { toast } from 'react-toastify';
import { TabTitle } from '../helpers/changePageTitle';

export default function Products(this: any) {
  TabTitle('productline. Produkty');

  const ref = useRef<HTMLInputElement>(null);
  const { productsService } = useProductsService();
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [height, setHeight] = useState(0);
  const [products, setProducts] = useState<ProductsRecord[] | undefined>(undefined);
  const [searchValue, setSearchValue] = useState('');
  const [refreshRecords, setRefreshRecords] = useState<boolean>(false);

  const searchTableProducts = (e: { target: { value: React.SetStateAction<string> } }) => {
    setSearchValue(e.target.value);
  };

  const searchProducts = products
    ? products.filter((product) => {
        return (
          product.sku.toLowerCase().indexOf(searchValue) >= 0 ||
          product.brand.toLowerCase().indexOf(searchValue) >= 0 ||
          product.productName.toLowerCase().indexOf(searchValue) >= 0 ||
          product.category.toLowerCase().indexOf(searchValue) >= 0 ||
          product.price.toString().toLowerCase().indexOf(searchValue) >= 0 ||
          product.quantity.toString().toLowerCase().indexOf(searchValue) >= 0 ||
          product.listingStatus.toString().indexOf(searchValue) >= 0
        );
      })
    : undefined;

  useEffect(() => {
    productsService.getProductList().then((res) => {
      const productsRecords = res.products.map((product) => ({
        id: product.id,
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
  }, [refreshRecords]);

  useLayoutEffect(() => {
    if (ref.current != null) {
      setHeight(ref.current.clientHeight);
    }
  }, []);

  const handleProductDelete = async (productId: string) => {
    if (!productId) return;
    try {
      // eslint-disable-next-line @typescript-eslint/no-unused-vars
      const res = await productsService.deleteProduct(productId);
      toast.success('Pomyślnie usunięto produkt');
      setRefreshRecords((prev) => !prev);
      setProducts(undefined);
    } catch {
      toast.error('Błąd podczas usuwania produktu');
    }
  };

  return (
    <>
      <Outlet />
      <ProductsTemplate
        productRecords={searchProducts}
        searchValue={searchValue}
        onChange={searchTableProducts}
        onProductDelete={handleProductDelete}
      />
    </>
  );
}
