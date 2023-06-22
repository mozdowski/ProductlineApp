import { AddProductRequest } from '../../../../interfaces/products/addProductRequest';
import { ProductForm } from '../../../../interfaces/products/productForm';
import Photos from '../../../molecules/formSections/addProductFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/addProductFormSections/ProductInfo/ProductInfo';
import ButtonsSection from '../../../molecules/formSections/addProductFormSections/buttonsSection/ButtonsSection';
import './css/addProductForm.css';

export default function AddProductForm({
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
  productForm: ProductForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<ProductForm>;
}) {
  return (
    <>
      <form onSubmit={onSubmit}>
        <div className="addProduct">
          <div className="detailsAboutProductForm">
            <ProductInfo productForm={productForm} onChange={onChange} errors={errors} />
          </div>
          <div className="productPhotosForm">
            <Photos uploadProductPhotos={uploadProductPhotos} photos={photos} />
          </div>
        </div>
        <ButtonsSection />
      </form>
    </>
  );
}
