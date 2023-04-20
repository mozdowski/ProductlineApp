using AutoMapper;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Infrastructure.Persistance.Entities.Platform;

namespace ProductlineApp.Infrastructure.Persistance.Mapping;

public class PlatformEntityMapper : Profile
{
    public PlatformEntityMapper()
    {
        this.CreateMap<Platform, PlatformEntity>().ReverseMap();
    }
}
