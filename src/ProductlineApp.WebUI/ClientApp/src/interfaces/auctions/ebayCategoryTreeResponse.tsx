export interface EbayCategoryTreeResponse {
  rootCategoryNode: CategoryTreeNode;
}

export interface CategoryTreeNode {
  category: EbayCategory;
  categoryTreeNodeLevel: number;
  childCategoryTreeNodes: CategoryTreeNode[];
}

interface EbayCategory {
  categoryId: string;
  categoryName: string;
}
