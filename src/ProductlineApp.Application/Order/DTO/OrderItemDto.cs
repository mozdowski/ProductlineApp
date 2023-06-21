namespace ProductlineApp.Application.Order.DTO;

public class OrderItemDto
{
    public string Sku { get; set; }

    public string OrderItemId { get; set; }

    public string Name { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal? DeliveryCost { get; set; }

    public decimal TotalPrice { get; set; }

    public string FulfillmentStatus { get; set; }
}
