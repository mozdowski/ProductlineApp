namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroProductCalalogueResponse
{
    public List<Product> Products { get; set; }

    // public Categories Categories { get; set; }

    public List<Filter> Filters { get; set; }

    public NextPageId NextPage { get; set; }

    public class Description
    {
        public List<Section> Sections { get; set; }
    }

    public class Section
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Type { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }

        public List<SimilarCategory> Similar { get; set; }
    }

    public class SimilarCategory
    {
        public string Id { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
    }

    public class RangeValue
    {
        public string From { get; set; }

        public string To { get; set; }
    }

    public class Options
    {
        public bool IdentifiesProduct { get; set; }

        public bool IsGTIN { get; set; }
    }

    public class Parameter
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public RangeValue RangeValue { get; set; }

        public List<string> Values { get; set; }

        public List<string> ValuesIds { get; set; }

        public List<string> ValuesLabels { get; set; }

        public string Unit { get; set; }

        public Options Options { get; set; }
    }

    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Description Description { get; set; }

        public Category Category { get; set; }

        public List<Image> Images { get; set; }

        public List<Parameter> Parameters { get; set; }

        public bool IsDraft { get; set; }
    }

    public class Subcategory
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }

    public class Path
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    // public class Categories
    // {
    //     public List<Subcategory> Subcategories { get; set; }
    //
    //     public List<Path> Path { get; set; }
    // }

    public class FilterValue
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string IdSuffix { get; set; }

        public int Count { get; set; }

        public bool Selected { get; set; }
    }

    public class Filter
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public List<FilterValue> Values { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public string Unit { get; set; }
    }

    public class NextPageId
    {
        public string Id { get; set; }
    }
}
