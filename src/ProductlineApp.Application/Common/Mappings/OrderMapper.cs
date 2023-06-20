using AutoMapper;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Enums;

namespace ProductlineApp.Application.Common.Mappings;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        this.CreateMap<Domain.Aggregates.Order.Order, OrderDtoResponse>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.PlacedAt))
            .ForMember(dest => dest.MaxDeliveryDate, opt => opt.MapFrom(src => src.DeliveryDate))
            .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BillingAddress))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.SubtotalPrice, opt => opt.MapFrom(src => src.SubtotalPrice))
            .ForMember(dest => dest.DeliveryCost, opt => opt.MapFrom(src => src.DeliveryCost))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.OrderLines.Count))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderLines))
            .ForMember(dest => dest.IsFulfilled, opt => opt.MapFrom(src => src.Status == OrderStatus.DELIVERED))
            .ForMember(dest => dest.Platform, opt => opt.Ignore())
            .ForMember(dest => dest.PlatformOrderId, opt => opt.MapFrom(src => src.PlatformOrderId))
            .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.IsPaid));

        this.CreateMap<OrderLine, OrderItemDto>()
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
            .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.PlatformListingId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.DeliveryCost, opt => opt.Ignore())
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FulfillmentStatus, opt => opt.Ignore());
    }
}
