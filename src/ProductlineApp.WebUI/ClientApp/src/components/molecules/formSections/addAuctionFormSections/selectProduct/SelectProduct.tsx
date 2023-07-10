import { AuctionForm } from '../../../../../interfaces/auctions/auctionForm';
import { ProductAuctionData } from '../../../../../interfaces/products/getProductsSKU';
import SelectProductInput from '../../../../atoms/inputs/selectProductInput/SelectProductInput';
import './css/selectProduct.css';

function SelectProduct({
  showFormSteps,
  products,
  value,
  onProductChange,
  errors,
}: {
  showFormSteps: any;
  products: ProductAuctionData[];
  value: string | undefined;
  onProductChange: (id: string) => void;
  errors: Partial<AuctionForm>;
}) {
  const handleProductChange = (name: string, value: string) => {
    onProductChange(value);
  };

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
          <SelectProductInput
            products={products}
            showFormSteps={showFormSteps}
            value={value}
            onChange={handleProductChange}
            error={errors ? errors.product : null}
          />
        </div>
      </div>
    </>
  );
}

export default SelectProduct;
