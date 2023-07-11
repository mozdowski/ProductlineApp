import { AuctionForm } from '../../interfaces/auctions/auctionForm';
import { CreateAllegroAuction } from '../../interfaces/auctions/createAllegroAuction';
import { ProductsRecord } from '../../interfaces/products/ProductsPageInteface';
import { AddProductRequest } from '../../interfaces/products/addProductRequest';
import { ProductAuctionData } from '../../interfaces/products/getProductsSKU';
import { ProductForm } from '../../interfaces/products/productForm';
import Photos from '../molecules/formSections/addProductFormSections/Photos/Photos';
import AddAuctionForm from '../organisms/forms/addAuctionForm/AddAuctionForm';
import AddProductForm from '../organisms/forms/addProductForm/AddProductForm';
import AddAuctionPageHeader from '../organisms/pageHeaders/AddAuctionPageHeader';
import AddProductPageHeader from '../organisms/pageHeaders/AddProductPageHeader';
import './css/AddAuctionTemplate.css';

export default function AddAuctionTemplate({
  products,
  selectedProduct,
  onProductChange,
  onSubmit,
  onAllegroFormSubmit,
  errors,
}: {
  products: ProductAuctionData[];
  selectedProduct: ProductAuctionData | null;
  onProductChange: (id: string) => void;
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  onAllegroFormSubmit: (form: CreateAllegroAuction) => void;
  errors: any;
}) {
  return (
    <>
      <AddAuctionPageHeader />
      <div className="content">
        <div className="addAuctionForm">
          <AddAuctionForm
            products={products}
            selectedProduct={selectedProduct}
            onProductChange={onProductChange}
            onSubmit={onSubmit}
            onAllegroFormSubmit={onAllegroFormSubmit}
            errors={errors}
          />
        </div>
      </div>
    </>
  );
}
