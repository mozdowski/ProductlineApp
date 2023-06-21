namespace ProductlineApp.Shared.Models.Ebay;

public class EbayOrdersResponse
{
    public string Href { get; set; }

    public int Total { get; set; }

    public string Prev { get; set; }

    public string? Next { get; set; }

    public int Limit { get; set; }

    public int Offset { get; set; }

    public EbayOrderResponse[] Orders { get; set; }
}
