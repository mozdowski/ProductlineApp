namespace ProductlineApp.Shared.Models.Ebay;

public class EbayCategoryTreeResponse
{
    public CategoryTreeNode RootCategoryNode { get; set; }

    public class CategoryTreeNode
    {
        public EbayCategory Category { get; set; }

        public int CategoryTreeNodeLevel { get; set; }

        public CategoryTreeNode[] ChildCategoryTreeNodes { get; set; }

        // public bool LeafCategoryTreeNode { get; set; }

        // public string ParentCategoryTreeNodeHref { get; set; }
    }

    public class EbayCategory
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
