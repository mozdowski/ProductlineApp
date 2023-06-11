namespace ProductlineApp.Application.Common.Platforms.Ebay.DTO;

public class EbayInventoryItemDto
{
    public string Sku { get; set; }

    public string Condition { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IEnumerable<string> ImageUrls { get; set; }

    public IDictionary<string, IEnumerable<string>>? Aspects { get; set; }

    public int Quantity { get; set; }
}
