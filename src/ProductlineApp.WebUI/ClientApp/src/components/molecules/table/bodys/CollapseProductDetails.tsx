import React from 'react';
import './css/CollapseProductDetails.css';
import ProductAuctionLinksSection from '../../auctionlinks/ProductAuctionLinksSection';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';

export const CollapseProductDetails = ({
  isOpen,
  productRecords,
}: {
  isOpen: any;
  productRecords: ProductsRecord[];
}) => {
  return (
    <tr className="productDetailsWrapper">
      <td></td>
      <td>
        <div className="productConditionSection">
          <h1>Stan: </h1>
          {productRecords.map((product) => (
            <h2>{product.quality}</h2>
          ))}
        </div>
      </td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td>
        <ProductAuctionLinksSection />
      </td>
    </tr>
  );
};
