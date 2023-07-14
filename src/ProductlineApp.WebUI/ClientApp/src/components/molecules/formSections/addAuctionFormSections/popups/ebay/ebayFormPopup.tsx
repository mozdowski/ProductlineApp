import './ebayFormPopup.css';
import EbayLogo from '../../../../../../assets/icons/ebay_icon.svg';
import { useEffect, useState } from 'react';
import NextButton from '../../../../../atoms/buttons/nextButton/nextButton';
import CancelButton from '../../../../../atoms/buttons/cancelButton/CancelButton';
import TreeSelect from '../../../../../atoms/common/selectTree';
import { TreeSelectOption } from '../../../../../../interfaces/common/treeSelectOption';
import { useAuctionsService } from '../../../../../../hooks/auctions/useAuctionsService';
import {
  CategoryTreeNode,
  EbayCategoryTreeResponse,
} from '../../../../../../interfaces/auctions/ebayCategoryTreeResponse';

interface EbayFormPopupProps {
  closePopup: () => void;
  onSubmit: (form: any) => void;
}

enum PopupPages {
  ProductSelect = 0,
  ParametersSet,
  ListingDetails,
}

function mapToTreeSelectOption(node: CategoryTreeNode): TreeSelectOption {
  const { category, childCategoryTreeNodes } = node;

  const treeOption: TreeSelectOption = {
    id: category.categoryId,
    label: category.categoryName,
  };

  if (childCategoryTreeNodes && childCategoryTreeNodes.length > 0) {
    treeOption.children = childCategoryTreeNodes.map(mapToTreeSelectOption);
  }

  return treeOption;
}

function mapEbayCategoryTreeResponseToTreeSelectOptions(
  response: EbayCategoryTreeResponse,
): TreeSelectOption[] {
  const { rootCategoryNode } = response;

  if (!rootCategoryNode) {
    return [];
  }

  return rootCategoryNode.childCategoryTreeNodes.map(mapToTreeSelectOption);
}

const EbayFormPopup: React.FC<EbayFormPopupProps> = ({ closePopup, onSubmit }) => {
  const { auctionsService } = useAuctionsService();
  const [categoryTree, setCategoryTree] = useState<TreeSelectOption[]>([]);
  const [selelectedCategoryId, setSelelectedCategoryId] = useState<string>();

  useEffect(() => {
    const fetchData = async () => {
      var ebayCategoryTreeResponse = await auctionsService.getEbayCategoryTree();
      var categoryTree = mapEbayCategoryTreeResponseToTreeSelectOptions(ebayCategoryTreeResponse);
      console.log(categoryTree);
      setCategoryTree(categoryTree);
    };

    fetchData();
  }, []);

  const handleConfirm = (detailsForm: any) => {
    onSubmit(detailsForm);
    closePopup();
  };

  const handleCancel = () => {
    closePopup();
  };

  const handleCategoryChange = (categoryId: string) => {
    if (!categoryId) return;
    setSelelectedCategoryId(categoryId);
  };

  return (
    <div className="overlayEbayPopup">
      <div
        className="ebayPopup"
        onClick={(e) => {
          e.stopPropagation();
        }}
      >
        <div className="ebayPopupSectionLabel">
          <img src={EbayLogo} className="ebayBrandIcon" />
          <p>Wybierz kategorie z katalogu Ebay</p>
        </div>
        <div className="ebayPopupBody">
          <TreeSelect value="" options={categoryTree} onChange={handleCategoryChange}></TreeSelect>
          <div className="ebayPopupBody">
            <div className="addAuctionAllEbayButtons">
              <div className="addAuctionEbayBackButton"></div>
              <div className="addAuctionEbayButtons">
                <CancelButton onClick={handleCancel} />
                <NextButton onClick={handleConfirm} />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
export default EbayFormPopup;
