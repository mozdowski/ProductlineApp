import { AuctionForm } from '../../interfaces/auctions/auctionForm';
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
  onSubmit,
  onProductChange,
  errors,
}: {
  products: ProductAuctionData[];
  selectedProduct: ProductAuctionData | null;
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  onProductChange: (id: string) => void;
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
            onSubmit={onSubmit}
            onProductChange={onProductChange}
            errors={errors}
          />
        </div>
      </div>
    </>
  );
}
