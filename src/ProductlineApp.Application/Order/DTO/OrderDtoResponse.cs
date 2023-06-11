using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Application.Order.DTO
{
    public class OrderDtoResponse
    {
        public string OrderId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? MaxDeliveryDate { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public Address CustomerAddress { get; set; }

        public Address ShippingAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal SubtotalPrice { get; set; }

        public decimal DeliveryCost { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }

        public bool IsFulfilled { get; set; }

        public bool IsPaid { get; set; }
    }
}
