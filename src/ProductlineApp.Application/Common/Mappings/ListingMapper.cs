using AutoMapper;
using ProductlineApp.Application.Listing.DTO;
using ProductlineApp.Domain.Aggregates.Listing.Entities;

namespace ProductlineApp.Application.Common.Mappings;

public class ListingMapper : Profile
{
    public ListingMapper()
    {
        this.CreateMap<Domain.Aggregates.Listing.Listing, ListingDtoResponse>();
        this.CreateMap<ListingInstance, ListingInstanceDtoResponse>();
        this.CreateMap<ListingInstance, ListingPublishDto>();
    }
}
