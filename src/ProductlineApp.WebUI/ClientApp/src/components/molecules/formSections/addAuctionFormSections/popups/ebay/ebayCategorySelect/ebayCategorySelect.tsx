import { useEffect, useState } from 'react';
import {
  CategoryTreeNode,
  EbayCategoryTreeResponse,
} from '../../../../../../../interfaces/auctions/ebayCategoryTreeResponse';
import { TreeSelectOption } from '../../../../../../../interfaces/common/treeSelectOption';
import { useAuctionsService } from '../../../../../../../hooks/auctions/useAuctionsService';
import TreeSelect from '../../../../../../atoms/common/selectTree';
import CancelButton from '../../../../../../atoms/buttons/cancelButton/CancelButton';
import NextButton from '../../../../../../atoms/buttons/nextButton/nextButton';
import { CircularProgress } from '@mui/material';

interface EbayCategory {
  id: string;
  name: string;
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

interface EbayCategorySelectProps {
  onCancel: () => void;
  onNext: (categoryId: string) => void;
}

const EbayCategorySelect: React.FC<EbayCategorySelectProps> = ({ onCancel, onNext }) => {
  const { auctionsService } = useAuctionsService();
  const [categoryTree, setCategoryTree] = useState<TreeSelectOption[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [selelectedCategory, setSelelectedCategory] = useState<EbayCategory>({
    id: '',
    name: '',
  });

  useEffect(() => {
    const fetchData = async () => {
      setIsLoading(true);
      const ebayCategoryTreeResponse = await auctionsService.getEbayCategoryTree();
      const categoryTree = mapEbayCategoryTreeResponseToTreeSelectOptions(ebayCategoryTreeResponse);

      setCategoryTree(categoryTree);
      setIsLoading(false);
    };

    fetchData();
  }, []);

  const handleCategoryChange = (id: string, name: string) => {
    if (!id || !name) return;
    setSelelectedCategory({
      id: id,
      name: name,
    });
  };

  const handleNext = () => {
    onNext(selelectedCategory.id);
  };

  return (
    <div className="ebayPopupBody">
      {isLoading && (
        <div className="loadingCircle">
          <CircularProgress sx={{ alignSelf: 'center', color: "var(--first-color)" }} />
        </div>
      )}
      {!isLoading && (
        <TreeSelect
          value={selelectedCategory.name}
          options={categoryTree}
          onChange={handleCategoryChange}
        />
      )}
      <div className="addAuctionAllEbayButtons">
        <div className="addAuctionEbayBackButton"></div>
        <div className="addAuctionEbayButtons">
          <CancelButton onClick={onCancel} />
          <NextButton onClick={handleNext} />
        </div>
      </div>
    </div>
  );
};

export default EbayCategorySelect;
