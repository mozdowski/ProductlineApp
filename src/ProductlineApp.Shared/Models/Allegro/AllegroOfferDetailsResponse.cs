namespace ProductlineApp.Shared.Models.Allegro;

public class AllegroOfferDetailsResponse
{
    public OfferDescription Description { get; set; }

    public class OfferDescription
    {
        public List<Section> Sections { get; set; }
    }

    public class Item
    {
        public string Type { get; set; }

        public string Content { get; set; }
    }

    public class Section
    {
        public List<Item> Items { get; set; }
    }
}
