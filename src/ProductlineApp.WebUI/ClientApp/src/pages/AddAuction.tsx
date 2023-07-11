import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { toast } from 'react-toastify';
import AddAuctionTemplate from '../components/templates/AddAuctionTemplate';
import { useAuctionsService } from '../hooks/auctions/useAuctionsService';
import { ProductAuctionData } from '../interfaces/products/getProductsSKU';
import { CreateAllegroAuction } from '../interfaces/auctions/createAllegroAuction';
import { CreateListingTemplateRequest } from '../interfaces/auctions/createListingTemplateRequest';

const validationSchema = Yup.object().shape({
  product: Yup.string().required('Produkt jest wymagany'),
});

export default function AddAuction() {
  const navigate = useNavigate();
  const { auctionsService } = useAuctionsService();
  const [products, setProducts] = useState<ProductAuctionData[]>();
  const [selectedProduct, setSelectedProduct] = useState<ProductAuctionData>({
    id: '',
    imageUrls: [],
    sku: '',
    brand: '',
    name: '',
    condition: 0,
    quantity: 0,
    price: 0,
    description: '',
  });
  const [allegroListingForm, setAllegroListingForm] = useState<CreateAllegroAuction | null>(null);
  const [errors, setErrors] = useState<any>({});

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

  useEffect(() => {
    if (allegroListingForm) {
      setAllegroListingForm((prev) => ({
        ...(prev as CreateAllegroAuction),
        description: selectedProduct.description as string,
        productId: selectedProduct.id as string,
        imagesUrls: selectedProduct.imageUrls as string[],
      }));
    }
  }, [selectedProduct]);

  const handleProductChange = (id: string) => {
    if (!id) return;
    setSelectedProduct(products?.find((x) => x.id === id) as ProductAuctionData);
  };

  const validateForm = async () => {
    try {
      await validationSchema.validate({ product: selectedProduct.id }, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<{ [index: string]: string }> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof { [index: string]: string }] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>): Promise<void> => {
    event.preventDefault();

    let listingId: string;

    const isValid = await validateForm();
    if (!isValid) return;

    const listingTemplateBody: CreateListingTemplateRequest = {
      title: selectedProduct.name,
      productId: selectedProduct.id,
      description: selectedProduct.description,
      price: selectedProduct.price,
      quantity: selectedProduct.quantity,
    };

    try {
      const createListingTemplateResponse = await auctionsService.createListingTemplate(
        listingTemplateBody,
      );
      listingId = createListingTemplateResponse.listingId;
      toast.success('Stworzono szablon aukcji');
    } catch {
      toast.error('Błąd podczas dodawania szablonu aukcji');
      return;
    }

    if (allegroListingForm) {
      const allegroListingBody: CreateAllegroAuction = allegroListingForm;
      allegroListingBody.listingId = listingId;

      try {
        const allegroResponse = await auctionsService.createAllegroListing(allegroListingBody);
        toast.success('Dodano aukcję na Allegro');
      } catch {
        toast.error('Błąd podczas dodawania aukcji na Allegro');
      }
    }

    navigate('/auctions');
  };

  const handleAllegroForm = (form: CreateAllegroAuction) => {
    form.description = selectedProduct.description;
    form.productId = selectedProduct.id;
    form.imagesUrls = selectedProduct.imageUrls;

    setAllegroListingForm(form);
  };

  return (
    <>
      {products && (
        <AddAuctionTemplate
          selectedProduct={selectedProduct}
          onSubmit={handleSubmit}
          onProductChange={handleProductChange}
          errors={errors}
          onAllegroFormSubmit={handleAllegroForm}
          products={products as ProductAuctionData[]}
        />
      )}
    </>
  );
}
