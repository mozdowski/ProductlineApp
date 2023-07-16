import React from 'react';
import './css/CollapseProductDetails.css';
import ProductAuctionLinksSection from '../../auctionlinks/ProductAuctionLinksSection';
import { ProductsRecord } from '../../../../interfaces/products/ProductsPageInteface';
import { PlatformEnum } from '../../../../enums/platform.enum';
import { ProductCondition } from '../../../../enums/productCondition';

export const CollapseProductDetails = ({
  platformsListedOn,
  condition,
}: {
  platformsListedOn: PlatformEnum[];
  condition: string;
}) => {
  return (
    <tr className="productDetailsWrapper">
      <td></td>
      <td>
        <div className="productConditionSection">
          <h1>Stan:</h1>
          <h2>{condition}</h2>
        </div>
      </td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td colSpan={2}>
        <ProductAuctionLinksSection platformsListedOn={platformsListedOn} />
      </td>
    </tr>
  );
};
