import BrandInput from '../../../../atoms/inputs/brandInput/BrandInput';
import CategoryInput from '../../../../atoms/inputs/categoryInput/CatrgoryInput';
import ConditionInput from '../../../../atoms/inputs/conditionInput/ConditionInput';
import PriceInput from '../../../../atoms/inputs/priceInput/PriceInput';
import ProductDescritionInput from '../../../../atoms/inputs/productDescriptionInput/ProcuctDescriptionInput';
import ProductNameInput from '../../../../atoms/inputs/produktNameInput/ProductNameInput';
import QuantityInput from '../../../../atoms/inputs/quantityInput/QuantityInput';
import SKUInput from '../../../../atoms/inputs/skuInptu/SKUInput';
import './css/productInfo.css';

function ProductInfo() {
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
            <SKUInput />
            <ProductNameInput />
          </div>
          <div className="secondLineInputs">
            <BrandInput />
            <QuantityInput />
            <PriceInput />
          </div>
          <div className="thirdLineInputs">
            <CategoryInput />
            <ConditionInput />
          </div>
          <div className="textAreaProductDescription">
            <ProductDescritionInput />
          </div>
        </div>
      </div>
    </>
  );
}

export default ProductInfo;
