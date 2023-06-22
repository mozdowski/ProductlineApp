import { AddProductRequest } from '../../../../../interfaces/products/addProductRequest';
import { ProductForm } from '../../../../../interfaces/products/productForm';
import BrandInput from '../../../../atoms/inputs/brandInput/BrandInput';
import CategoryInput from '../../../../atoms/inputs/categoryInput/CatrgoryInput';
import ConditionInput from '../../../../atoms/inputs/conditionInput/ConditionInput';
import PriceInput from '../../../../atoms/inputs/priceInput/PriceInput';
import ProductDescritionInput from '../../../../atoms/inputs/productDescriptionInput/ProcuctDescriptionInput';
import ProductNameInput from '../../../../atoms/inputs/produktNameInput/ProductNameInput';
import QuantityInput from '../../../../atoms/inputs/quantityInput/QuantityInput';
import SKUInput from '../../../../atoms/inputs/skuInptu/SKUInput';
import './css/productInfo.css';

function ProductInfo({
  productForm,
  onChange,
}: {
  productForm: ProductForm;
  onChange: (name: string, value: string | number) => void;
}) {
  return (
    <>
      <div className="productInfo">
        <div className="sectionLabel">
          <div className="sectionNumber">
            <h1>1</h1>
          </div>
          <p>Informacje o Produkcie</p>
        </div>
        <div className="addProductInputs">
          <div className="firsLineInputs">
            <SKUInput value={productForm.sku} onChange={onChange} />
            <ProductNameInput value={productForm.name} onChange={onChange} />
          </div>
          <div className="secondLineInputs">
            <BrandInput value={productForm.brand} onChange={onChange} />
            <QuantityInput value={productForm.quantity} onChange={onChange} />
            <PriceInput value={productForm.price} onChange={onChange} />
          </div>
          <div className="thirdLineInputs">
            <CategoryInput value={productForm.category} onChange={onChange} />
            <ConditionInput value={productForm.condition} onChange={onChange} />
          </div>
          <div className="textAreaProductDescription">
            <ProductDescritionInput value={productForm.description} onChange={onChange} />
          </div>
        </div>
      </div>
    </>
  );
}

export default ProductInfo;
