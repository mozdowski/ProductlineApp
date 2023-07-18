import { AddProductRequest } from '../../interfaces/products/addProductRequest';
import { ProductData } from '../../interfaces/products/getProductsSKU';
import { ProductForm } from '../../interfaces/products/productForm';
import Photos from '../molecules/formSections/addProductFormSections/Photos/Photos';
import AddProductForm from '../organisms/forms/addProductForm/AddProductForm';
import EditProductForm from '../organisms/forms/editProductForm/EditProductForm';
import AddProductPageHeader from '../organisms/pageHeaders/AddProductPageHeader';
import EditProductPageHeader from '../organisms/pageHeaders/EditProductPageHeader';
import './css/editProductTemplate.css';

export default function EditProductTemplate({
  uploadProductPhotos,
  photos,
  onSubmit,
  productForm,
  onChange,
  errors,
  selectedProductData
}: {
  uploadProductPhotos: any;
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  productForm: ProductForm;
  onChange: (name: string, value: string | number) => void;
  errors: any;
  selectedProductData: ProductData;
}) {
  return (
    <>
      <EditProductPageHeader />
      <div className="content">
        <div className="editProductForm">
          <EditProductForm
            uploadProductPhotos={uploadProductPhotos}
            photos={photos}
            onSubmit={onSubmit}
            productForm={productForm}
            onChange={onChange}
            errors={errors}
            selectedProductData={selectedProductData} />
        </div>
      </div>
    </>
  );
}
