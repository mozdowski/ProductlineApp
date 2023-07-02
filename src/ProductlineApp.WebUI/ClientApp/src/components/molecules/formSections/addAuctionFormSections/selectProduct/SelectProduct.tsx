import { AuctionForm } from '../../../../../interfaces/auctions/auctionForm';
import { ProductSKU } from '../../../../../interfaces/products/getProductsSKU';
import SelectProductInput from '../../../../atoms/inputs/selectProductInput/SelectProductInput';
import './css/selectProduct.css';

function SelectProduct({
  showFormSteps,
  productsSKURecords,
  auctionForm,
  onChange,
  errors,
}: {
  showFormSteps: any,
  productsSKURecords: ProductSKU[],
  auctionForm: AuctionForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<AuctionForm>;
}) {
  return (
    <>
      <div className="selectProduct">
        <div className="sectionLabel">
          <div className="sectionNumber">
            <h1>1</h1>
          </div>
          <p>Wyberz Produkt</p>
        </div>
        <div className="selectProducctInput">
          <SelectProductInput productsSKURecords={productsSKURecords} showFormSteps={showFormSteps} value={auctionForm.sku} onChange={function (name: string, value: string): void {
            throw new Error('Function not implemented.');
          }} error={undefined} />
        </div>
      </div>
    </>
  );
}

export default SelectProduct;
