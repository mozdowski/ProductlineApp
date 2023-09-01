import { PlatformEnum } from '../../enums/platform.enum';
import { CreateAllegroAuction } from '../../interfaces/auctions/createAllegroAuction';
import { CreateEbayAuctionRequest } from '../../interfaces/auctions/createEbayAuctionRequest';
import { ProductAuctionData } from '../../interfaces/products/getProductsSKU';
import AddAuctionForm from '../organisms/forms/addAuctionForm/AddAuctionForm';
import AddAuctionPageHeader from '../organisms/pageHeaders/AddAuctionPageHeader';
import './css/AddAuctionTemplate.css';

export default function AddAuctionTemplate({
  products,
  selectedProduct,
  onProductChange,
  onSubmit,
  onAllegroFormSubmit,
  onEbayFormSubmit,
  errors,
  platformConnections,
  assignedPortals,
  confirmDisabled
}: {
  products: ProductAuctionData[];
  selectedProduct: ProductAuctionData | null;
  onProductChange: (id: string) => void;
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  onAllegroFormSubmit: (form: CreateAllegroAuction) => void;
  onEbayFormSubmit: (form: CreateEbayAuctionRequest) => void;
  errors: any;
  platformConnections: string[];
  assignedPortals: PlatformEnum[];
  confirmDisabled: boolean;
}) {
  return (
    <>
      <AddAuctionPageHeader />
      <div className="content">
        <div className="addAuctionForm">
          <AddAuctionForm
            products={products}
            selectedProduct={selectedProduct}
            onProductChange={onProductChange}
            onSubmit={onSubmit}
            onAllegroFormSubmit={onAllegroFormSubmit}
            onEbayFormSubmit={onEbayFormSubmit}
            errors={errors}
            platformConnections={platformConnections}
            assignedPortals={assignedPortals}
            confirmDisabled={confirmDisabled}
          />
        </div>
      </div>
    </>
  );
}
