import { FormEvent, useEffect, useState } from 'react';
import AddProductTemplate from '../components/templates/AddProductTemplate';
import { AddProductRequest } from '../interfaces/products/addProductRequest';
import { ProductForm } from '../interfaces/products/productForm';
import { useProductsService } from '../hooks/products/useProductsService';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { toast } from 'react-toastify';
import AddAuctionForm from '../components/organisms/forms/addAuctionForm/AddAuctionForm';
import AddAuctionTemplate from '../components/templates/AddAuctionTemplate';
import { AuctionForm } from '../interfaces/auctions/auctionForm';
import { useAuctionsService } from '../hooks/auctions/useAuctionsService';
import { ProductDtoResponse } from '../interfaces/products/getProductsResponse';
import { ProductAuctionData } from '../interfaces/products/getProductsSKU';

const allegroAuctionSchema = Yup.object().shape({
  name: Yup.string().required('Nazwa jest wymagana'),
  quantity: Yup.number().required('Ilość jest wymagana').positive('Ilość musi być dodatnia'),
  price: Yup.number().required('Cena jest wymagana').positive('Cena musi być dodatnia'),
  condition: Yup.string().required('Stan jest wymagany'),
  description: Yup.string().required('Opis jest wymagany'),
  photos: Yup.mixed()
    .nullable()
    .test('file', 'Wymagane co najmniej jedno zdjęcie', (value) => {
      return value instanceof FileList && value.length > 0;
    }),
});

export default function AddAuction() {
  const navigate = useNavigate();
  const { auctionsService } = useAuctionsService();
  const [products, setProducts] = useState<ProductAuctionData[]>();
  const [selectedProduct, setSelectedProduct] = useState<ProductAuctionData | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const productsResponse = await auctionsService.getProductsForAution();
        setProducts(
          productsResponse.products.map((product) => ({
            id: product.id,
            imageUrls: [product.imageUrl, ...product.gallery],
            sku: product.sku,
            brand: product.brand,
            name: product.name,
            condition: product.condition,
            quantity: product.quantity,
            price: product.price,
            description: product.description,
          })),
        );
      } catch {
        toast.error('Błąd przy pobieraniu listy produktów');
      }
    };

    fetchData();
  }, []);

  const handleProductChange = (id: string) => {
    if (!id) return;
    setSelectedProduct(products?.find((x) => x.id === id) as ProductAuctionData);
  };

  const validateForm = (): boolean => {
    return true;
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>): void => {
    event.preventDefault();

    const isValid = validateForm();
    if (!isValid) return;
  };

  return (
    <>
      {products && (
        <AddAuctionTemplate
          selectedProduct={selectedProduct}
          onSubmit={handleSubmit}
          onProductChange={handleProductChange}
          errors={null}
          products={products as ProductAuctionData[]}
        />
      )}
    </>
  );
}
