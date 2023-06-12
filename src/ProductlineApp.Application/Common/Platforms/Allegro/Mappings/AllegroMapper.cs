using AutoMapper;
using ProductlineApp.Application.Common.Platforms.Allegro.DTO;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Application.Order.DTO;
using ProductlineApp.Domain.Enums;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Allegro;
using Address = ProductlineApp.Domain.ValueObjects.Address;

namespace ProductlineApp.Application.Common.Platforms.Allegro.Mappings;

public class AllegroMapper : Profile
{
    public AllegroMapper()
    {
        this.MapOrders();
        this.MapListings();
        this.CreateMap<AllegroProductCalalogueResponse, AllegroProductListDto>();
        this.CreateMap<AllegroProductParametersResponse, AllegroProductParametersDtoResponse>();
    }

    private void MapOrders()
    {
        this.CreateMap<CheckoutForm, OrderDtoResponse>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.LineItems.First().BoughtAt))
            .ForMember(dest => dest.MaxDeliveryDate, opt => opt.MapFrom(src => DateTime.Parse(src.Delivery.Time.Guaranteed.To)))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"))
            .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Buyer.Email))
            .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Buyer.PhoneNumber))
            .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.Buyer.Address))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.Delivery.Address))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Summary.TotalToPay.Amount))
            .ForMember(dest => dest.SubtotalPrice, opt => opt.MapFrom(src => src.Summary.TotalToPay.Amount - src.Delivery.Cost.Amount))
            .ForMember(dest => dest.DeliveryCost, opt => opt.MapFrom(src => src.Delivery.Cost.Amount))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.LineItems.Count()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapToOrderStatus(src.Status, src.Fulfillment.Status)))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.LineItems))
            .ForMember(dest => dest.IsFulfilled, opt => opt.MapFrom(src => src.Fulfillment.Status == FullfilmentStatus.PICKED_UP.ToString()))
            .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.Payment.PaidAmount.Amount == src.Summary.TotalToPay.Amount));

        this.CreateMap<LineItem, OrderItemDto>()
            .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Offer.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price.Amount))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Reconciliation.Value.Amount * src.Quantity));

        this.CreateMap<Shared.Models.Allegro.Address, Address>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => "Poland"))
            .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.PostCode))
            .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.StreetNumber, opt => opt.Ignore());

        this.CreateMap<Shared.Models.Allegro.Address2, Address>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => "Poland"))
            .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.ZipCode))
            .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.StreetNumber, opt => opt.Ignore());

        this.CreateMap<Shared.Models.Allegro.Address3, Address>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => "Poland"))
            .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.ZipCode))
            .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.StreetNumber, opt => opt.Ignore());
    }

    private void MapListings()
    {
        this.CreateMap<AllegroUserOffersResponse.Offer, ListingDtoResponse>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ListingId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.PlatformListingUrl, opt => opt.Ignore())
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.External.Id) ? Guid.Empty : Guid.Parse(src.External.Id)))
            .ForMember(dest => dest.Sku, opt => opt.Ignore())
            .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => Image.Create(src.PrimaryImage.Url)))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.SellingMode.Price.Amount))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Stock.Available))
            .ForMember(dest => dest.DaysToExpire, opt => opt.MapFrom(src => CalculateDaysToExpire(src.Publication.EndingAt)))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Publication.Status == "ACTIVE" ? 1 : 0));

        this.CreateMap<AllegroCreateListingDtoRequest, AllegroCreateListingRequest>()
            .ForMember(dest => dest.ProductSet, opt => opt.MapFrom(src => new List<ProductSet>()
            {
                new ProductSet()
                {
                    Product = new AllegroListingProduct()
                    {
                        Id = src.AllegroProductId,
                        Parameters = src.Parameters,
                    },
                    Quantity = new Quantity()
                    {
                        Value = 1,
                    },
                },
            }))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            // .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Id = src.CategoryId }))
            .ForMember(dest => dest.Parameters, opt => opt.Ignore())
            .ForMember(dest => dest.B2b, opt => opt.MapFrom(src => new B2b()
                {
                    BuyableOnlyByBusiness = false,
                }))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => new Stock()
            {
                Available = src.Quantity,
                Unit = "UNIT",
            }))
            .ForMember(dest => dest.Language, opt => opt.MapFrom(src => "pl-PL"))
            .ForMember(dest => dest.AfterSalesServices, opt => opt.MapFrom(src => new AfterSalesServices
            {
                ImpliedWarranty = new ImpliedWarranty { Id = src.ImpliedWarrantyId },
                ReturnPolicy = new ReturnPolicy { Id = src.ReturnPolicyId },
            }))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.SellingMode, opt => opt.MapFrom(src => new SellingMode
            {
                Format = "BUY_NOW",
                Price = new Price { Amount = src.Price, Currency = "PLN" },
            }))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => new Description
            {
                Sections = new List<Section>
                {
                    new Section
                    {
                        Items = new List<Item2>
                        {
                            new Item2 { Type = "TEXT", Content = src.Description },
                        },
                    },
                },
            }))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImagesUrls))
            .ForMember(dest => dest.Publication, opt => opt.MapFrom(src => new Publication
            {
                Duration = src.Duration.ToString(),
                StartingAt = src.StartingAt,
                Status = "ACTIVE",
                Republish = src.Republish,
            }))
            .ForMember(dest => dest.Delivery, opt => opt.MapFrom(src => src.Delivery))
            .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => new Payments()
            {
                Invoice = Payments.PaymentInvoice.VAT.ToString(),
            }))
            .ForMember(dest => dest.External, opt => opt.MapFrom(src => new External()
            {
                Id = src.ProductId.ToString(),
            }));
    }

    private static OrderStatus MapToOrderStatus(string mainStatus, string fullfilmentStatus)
    {
        var mainStatusEnum = Enum.Parse<PurchaseStatus>(mainStatus);
        var fullfilmentStatusEnum = Enum.Parse<FullfilmentStatus>(fullfilmentStatus);

        if (mainStatusEnum == PurchaseStatus.READY_FOR_PROCESSING && new[] { FullfilmentStatus.NEW, FullfilmentStatus.PROCESSING, FullfilmentStatus.READY_FOR_SHIPMENT }.Contains(fullfilmentStatusEnum))
            return OrderStatus.PENDING;

        if (fullfilmentStatusEnum == FullfilmentStatus.SENT)
            return OrderStatus.SHIPPED;

        if (fullfilmentStatusEnum == FullfilmentStatus.PICKED_UP)
            return OrderStatus.DELIVERED;

        if (mainStatusEnum == PurchaseStatus.CANCELLED)
            return OrderStatus.CANCELLED;

        return OrderStatus.PENDING;
    }

    private static int? CalculateDaysToExpire(DateTime? expirationDate)
    {
        if (expirationDate.HasValue)
        {
            return (expirationDate.Value - DateTime.Now).Days;
        }

        return null;
    }

    // private static string GetDuration(AllegroDurationPeriods duration)
    // {
    //     switch (duration)
    //     {
    //         case AllegroDurationPeriods.PT24H:
    //             return "24H";
    //         case AllegroDurationPeriods.P3D:
    //             return "P3D";
    //         case AllegroDurationPeriods.P5D:
    //             return "P5D";
    //         case AllegroDurationPeriods.P7D:
    //             return "P7D";
    //         case AllegroDurationPeriods.P10D:
    //             return "P10D";
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(duration), "Invalid duration period.");
    //     }
    // }
}
