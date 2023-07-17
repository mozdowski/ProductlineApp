import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { toast } from 'react-toastify';
import AddAuctionTemplate from '../components/templates/AddAuctionTemplate';
import { useAuctionsService } from '../hooks/auctions/useAuctionsService';
import { ProductAuctionData } from '../interfaces/products/getProductsSKU';
import { CreateAllegroAuction } from '../interfaces/auctions/createAllegroAuction';
import { CreateListingTemplateRequest } from '../interfaces/auctions/createListingTemplateRequest';
import { useSelectedProduct } from '../hooks/auctions/useSelectedProduct';
import { CreateEbayAuctionRequest } from '../interfaces/auctions/createEbayAuctionRequest';

const validationSchema = Yup.object().shape({
  product: Yup.string().required('Produkt jest wymagany'),
});

export default function AddAuction() {
  const navigate = useNavigate();
  const { selectedProduct, setSelectedProduct } = useSelectedProduct();
  const { auctionsService } = useAuctionsService();
  const [products, setProducts] = useState<ProductAuctionData[]>();
  const [allegroListingForm, setAllegroListingForm] = useState<CreateAllegroAuction | null>(null);
  const [ebayListingForm, setEbayListingForm] = useState<CreateEbayAuctionRequest | null>(null);
  const [errors, setErrors] = useState<any>({});
  const [platformConnections, setPlatformConnections] = useState<string[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [productsResponse, connections] = await Promise.all([
          auctionsService.getProductsForAution(),
          auctionsService.getPlatformConnections(),
        ]);

        setPlatformConnections(connections);
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

    if (allegroListingForm) {
      allegroListingForm.description = selectedProduct.description;
      allegroListingForm.productId = selectedProduct.id;
      allegroListingForm.imagesUrls = selectedProduct.imageUrls;
    }

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
      const createListingTemplateResponse = await toast.promise(
        auctionsService.createListingTemplate(listingTemplateBody),
        {
          pending: 'Tworzenie szablonu aukcji...',
          success: 'Stworzono szablon aukcji',
          error: 'Błąd podczas dodawania szablonu aukcji',
        },
      );
      listingId = createListingTemplateResponse.listingId;
    } catch {
      toast.error('Błąd podczas dodawania szablonu aukcji');
      return;
    }

    if (allegroListingForm) {
      const allegroListingBody: CreateAllegroAuction = allegroListingForm;
      allegroListingBody.listingId = listingId;

      try {
        await toast.promise(auctionsService.createAllegroListing(allegroListingBody), {
          pending: 'Dodawanie aukcji na Allegro...',
          success: 'Dodano aukcję na Allegro',
          error: 'Błąd podczas dodawania aukcji na Allegro',
        });
      } catch {
        toast.error('Błąd podczas dodawania aukcji na Allegro');
      }
    }

    if (ebayListingForm) {
      const ebayListingBody: CreateEbayAuctionRequest = ebayListingForm;
      ebayListingBody.listingId = listingId;

      try {
        await toast.promise(auctionsService.createEbayListing(ebayListingBody), {
          pending: 'Dodawanie aukcji na Ebay...',
          success: 'Dodano aukcję na Ebay',
          error: 'Błąd podczas dodawania aukcji na Ebay',
        });
      } catch {
        toast.error('Błąd podczas dodawania aukcji na Ebay');
      }
    }

    navigate('/auctions');
  };

  const handleAllegroForm = (form: CreateAllegroAuction) => {
    setAllegroListingForm(form);
  };

  const handleEbayForm = (form: CreateEbayAuctionRequest) => {
    setEbayListingForm(form);
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
          platformConnections={platformConnections}
          onEbayFormSubmit={handleEbayForm}
        />
      )}
    </>
  );
}
