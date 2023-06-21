using ProductlineApp.Shared.Models.Allegro;

namespace ProductlineApp.Application.Common.Platforms.Allegro.DTO;

public class AllegroCreateListingDtoRequest
{
    public string Name { get; set; }

    public string AllegroProductId { get; set; }

    public string Description { get; set; }

    // public string CategoryId { get; set; }

    public string ImpliedWarrantyId { get; set; }

    public string ReturnPolicyId { get; set; }

    public decimal Price { get; set; }

    public Location Location { get; set; }

    public Guid ProductId { get; set; }

    public List<Parameter> Parameters;

    public AllegroDurationPeriods Duration { get; set; }

    public bool Republish { get; set; }

    public IEnumerable<string> ImagesUrls { get; set; }

    public Delivery Delivery { get; set; }

    public int Quantity { get; set; }

    public DateTime? StartingAt { get; set; } = null;

    public class ParameterRangeValue
    {
        public string From { get; set; }

        public string To { get; set; }
    }
}
