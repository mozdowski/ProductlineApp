namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroCatalogueProductDetailsResponse
{
    public class ProductCategory
    {
        public string Id { get; set; }
        public List<Category> Similar { get; set; }
    }

    public class ProdouctRangeValue
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class ProductOptions
    {
        public bool IdentifiesProduct { get; set; }
        public bool IsGTIN { get; set; }
    }

    public class ProductParameter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ProdouctRangeValue RangeValue { get; set; }
        public List<string> Values { get; set; }
        public List<string> ValuesIds { get; set; }
        public List<string> ValuesLabels { get; set; }
        public string Unit { get; set; }
        public ProductOptions Options { get; set; }
    }

    public class ProductOfferRequirements
    {
        public string Id { get; set; }
        public List<Parameter> Parameters { get; set; }
    }

    public class ProductCompatibilityItem
    {
        public string Text { get; set; }
    }

    public class ProductCompatibilityList
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public List<ProductCompatibilityItem> Items { get; set; }
    }

    public class ProductTecdocSpecificationItem
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
    }

    public class ProductDescriptionItem
    {
        public string Type { get; set; }
    }

    public class ProductDescriptionSection
    {
        public List<ProductDescriptionItem> Items { get; set; }
    }

    public class ProductTecdocSpecification
    {
        public string Id { get; set; }
        public List<ProductTecdocSpecificationItem> Items { get; set; }
    }

    public class ProductDescription
    {
        public List<ProductDescriptionSection> Sections { get; set; }
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public ProductCategory Category { get; set; }
    public List<object> Images { get; set; }
    public List<ProductParameter> Parameters { get; set; }
    public ProductOfferRequirements OfferRequirements { get; set; }
    public ProductCompatibilityList CompatibilityList { get; set; }
    public ProductTecdocSpecification TecdocSpecification { get; set; }
    public ProductDescription Description { get; set; }
    public bool IsDraft { get; set; }
}
