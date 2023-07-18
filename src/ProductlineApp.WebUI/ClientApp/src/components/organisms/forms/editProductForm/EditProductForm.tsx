import { ProductForm } from '../../../../interfaces/products/productForm';
import Photos from '../../../molecules/formSections/editProductFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/editProductFormSections/ProductInfo/ProductInfo';
import ButtonsSection from '../../../molecules/formSections/addProductFormSections/buttonsSection/ButtonsSection';
import './css/editProductForm.css';
import { ProductData } from '../../../../interfaces/products/getProductsSKU';

export default function EditProductForm({
  uploadProductPhotos,
  photos,
  onSubmit,
  selectedProductData,
  onChange,
  errors,
}: {
  uploadProductPhotos: any;
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  selectedProductData: ProductData;
  productForm: ProductForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<ProductForm>;
}) {
  return (
    <>
      <form onSubmit={onSubmit}>
        <div className="editProduct">
          <div className="detailsAboutEditedProductForm">
            <ProductInfo selectedProductData={selectedProductData} onChange={onChange} errors={errors} />
          </div>
          <div className="editedProductPhotosForm">
            <Photos
              uploadProductPhotos={uploadProductPhotos}
              photos={selectedProductData ? selectedProductData.imageUrls : []}
              error={errors.photos}
            />
          </div>
        </div>
        <ButtonsSection />
      </form>
    </>
  );
}
