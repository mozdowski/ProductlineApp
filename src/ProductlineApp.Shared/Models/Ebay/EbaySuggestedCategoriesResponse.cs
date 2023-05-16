namespace ProductlineApp.Shared.Models.Ebay;

public class EbaySuggestedCategoriesResponse
{
    public CategorySuggestion[] CategorySuggestions { get; set; }

    public string CategoryTreeId { get; set; }

    public string CategoryTreeVersion { get; set; }

    public class CategorySuggestion
    {
        public Category Category { get; set; }

        public CategoryTreeNodeAncestor[] CategoryTreeNodeAncestors { get; set; }

        public int CategoryTreeNodeLevel { get; set; }

        public string Relevancy { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }

    public class CategoryTreeNodeAncestor
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategorySubtreeNodeHref { get; set; }

        public int CategoryTreeNodeLevel { get; set; }
    }
}
