namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroCategoriesResponse
{
    public List<Category> Categories { get; set; }

    public class Category
    {
        public string Id { get; set; }

        public bool Leaf { get; set; }

        public string Name { get; set; }

        public CategoryOptions Options { get; set; }

        public CategoryParent Parent { get; set; }
    }

    public class CategoryOptions
    {
        public bool Advertisement { get; set; }

        public bool AdvertisementPriceOptional { get; set; }

        public bool VariantsByColorPatternAllowed { get; set; }

        public bool OffersWithProductPublicationEnabled { get; set; }

        public bool ProductCreationEnabled { get; set; }

        public bool CustomParametersEnabled { get; set; }
    }

    public class CategoryParent
    {
        public string Id { get; set; }
    }
}
