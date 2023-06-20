using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Enums;

namespace ProductlineApp.Application.Order.DTO
{
    public class OrderDtoResponse
    {
        public Guid OrderId { get; set; }

        public string PlatformOrderId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? MaxDeliveryDate { get; set; }

        public ShippingAddress ShippingAddress { get; set; }

        public BillingAddress BillingAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal SubtotalPrice { get; set; }

        public decimal DeliveryCost { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }

        public bool IsFulfilled { get; set; }

        public bool IsPaid { get; set; }

        public PlatformNames Platform { get; set; }
    }
}
