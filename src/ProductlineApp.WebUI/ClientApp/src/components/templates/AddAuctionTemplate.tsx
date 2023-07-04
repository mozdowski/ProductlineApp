import { AuctionForm } from '../../interfaces/auctions/auctionForm';
import { AddProductRequest } from '../../interfaces/products/addProductRequest';
import { ProductSKU } from '../../interfaces/products/getProductsSKU';
import { ProductForm } from '../../interfaces/products/productForm';
import Photos from '../molecules/formSections/addProductFormSections/Photos/Photos';
import AddAuctionForm from '../organisms/forms/addAuctionForm/AddAuctionForm';
import AddProductForm from '../organisms/forms/addProductForm/AddProductForm';
import AddAuctionPageHeader from '../organisms/pageHeaders/AddAuctionPageHeader';
import AddProductPageHeader from '../organisms/pageHeaders/AddProductPageHeader';
import './css/AddAuctionTemplate.css';

export default function AddAuctionTemplate({
  productsSKURecords,
  uploadProductPhotos,
  photos,
  onSubmit,
  auctionForm,
  onChange,
  errors,
}: {
  productsSKURecords: ProductSKU[];
  uploadProductPhotos: any;
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  auctionForm: AuctionForm;
  onChange: (name: string, value: string | number) => void;
  errors: any;
}) {
  return (
    <>
      <AddAuctionPageHeader />
      <div className="content">
        <div className="addAuctionForm">
          <AddAuctionForm
            productsSKURecords={productsSKURecords}
            photos={photos}
            onSubmit={onSubmit}
            auctionForm={auctionForm}
            onChange={onChange}
            errors={errors}
          />
        </div>
      </div>
    </>
  );
}
