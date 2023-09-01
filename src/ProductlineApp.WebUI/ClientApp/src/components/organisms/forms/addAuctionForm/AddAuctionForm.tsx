import { ChangeEvent, useState } from 'react';
import Photos from '../../../molecules/formSections/addAuctionFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/addAuctionFormSections/ProductInfo/ProductInfo';
import AuctionPortals from '../../../molecules/formSections/addAuctionFormSections/auctionPortals/AuctionPortals';
import ButtonsSection from '../../../molecules/formSections/addAuctionFormSections/buttonsSection/ButtonsSection';
import SelectProduct from '../../../molecules/formSections/addAuctionFormSections/selectProduct/SelectProduct';
import './css/addAuctionForm.css';
import { ProductAuctionData } from '../../../../interfaces/products/getProductsSKU';
import { CreateAllegroAuction } from '../../../../interfaces/auctions/createAllegroAuction';
import { CreateEbayAuctionRequest } from '../../../../interfaces/auctions/createEbayAuctionRequest';
import { PlatformEnum } from '../../../../enums/platform.enum';

export default function AddAuctionForm({
  products,
  selectedProduct,
  onSubmit,
  onProductChange,
  onAllegroFormSubmit,
  onEbayFormSubmit,
  errors,
  platformConnections,
  assignedPortals,
  confirmDisabled
}: {
  products: ProductAuctionData[];
  selectedProduct: ProductAuctionData | null;
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  onProductChange: (id: string) => void;
  onAllegroFormSubmit: (form: CreateAllegroAuction) => void;
  onEbayFormSubmit: (form: CreateEbayAuctionRequest) => void;
  errors: any;
  platformConnections: string[];
  assignedPortals: PlatformEnum[];
  confirmDisabled: boolean;
}) {
  const [showFormSteps, setSelectedOption] = useState('');

  const handleShowFormSteps = (e: ChangeEvent<HTMLSelectElement>) => {
    const optionValue = e.target.value;
    setSelectedOption(optionValue);
  };

  return (
    <>
      <div className="addAuction">
        <form className="addAuctionFirstSection" onSubmit={onSubmit}>
          <SelectProduct
            products={products}
            value={selectedProduct?.id}
            showFormSteps={(e: ChangeEvent<HTMLSelectElement>) => handleShowFormSteps(e)}
            onProductChange={onProductChange}
            errors={errors}
          />
          {showFormSteps != ' ' && selectedProduct && selectedProduct?.id !== '' && (
            <ProductInfo selectedProduct={selectedProduct} onChange={() => {}} />
          )}
          <ButtonsSection confirmDisabled={confirmDisabled}/>
        </form>
        {showFormSteps != ' ' && selectedProduct && selectedProduct?.id !== '' && (
          <div className="addAuctionSecondSection">
            <Photos photos={selectedProduct ? selectedProduct.imageUrls : []} />
            <AuctionPortals
              onAllegroFormSubmit={onAllegroFormSubmit}
              platformConnections={platformConnections}
              onEbayFormSubmit={onEbayFormSubmit}
              assignedPortals={assignedPortals}
            />
          </div>
        )}
      </div>
    </>
  );
}
