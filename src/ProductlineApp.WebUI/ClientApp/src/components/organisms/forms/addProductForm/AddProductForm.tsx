import Photos from '../../../molecules/formSections/addProductFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/addProductFormSections/ProductInfo/ProductInfo';
import ButtonsSection from '../../../molecules/formSections/addProductFormSections/buttonsSection/ButtonsSection';
import './css/addProductForm.css';

export default function AddProductForm({
  uploadProductPhotos,
  photos,
}: {
  uploadProductPhotos: any;
  photos: string[];
}) {
  return (
    <>
      <form>
        <div className="addProduct">
          <div className="detailsAboutProductForm">
            <ProductInfo />
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
