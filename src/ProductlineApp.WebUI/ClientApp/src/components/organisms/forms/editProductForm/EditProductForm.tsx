import { ProductForm } from '../../../../interfaces/products/productForm';
import Photos from '../../../molecules/formSections/editProductFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/editProductFormSections/ProductInfo/ProductInfo';
import ButtonsSection from '../../../molecules/formSections/addProductFormSections/buttonsSection/ButtonsSection';
import './css/editProductForm.css';
import { ProductEditForm } from '../../../../interfaces/products/productEditForm';

export default function EditProductForm({
  uploadProductPhotos,
  photos,
  onSubmit,
  productForm,
  onChange,
  errors,
}: {
  uploadProductPhotos: any;
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  productForm: ProductEditForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<ProductForm>;
}) {
  return (
    <>
      <form onSubmit={onSubmit}>
        <div className="editProduct">
          <div className="detailsAboutEditedProductForm">
            <ProductInfo productForm={productForm} onChange={onChange} errors={errors} />
          </div>
          <div className="editedProductPhotosForm">
            <Photos
              uploadProductPhotos={uploadProductPhotos}
              photos={productForm.gallery}
              error={errors.photos}
            />
          </div>
        </div>
        <ButtonsSection />
      </form>
    </>
  );
}
