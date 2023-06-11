using AutoMapper;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Infrastructure.Persistance.Entities.User;

namespace ProductlineApp.Infrastructure.Persistance.Mapping;

public class UserEntityMapper : Profile
{
    public UserEntityMapper()
    {
        this.CreateMap<PlatformConnection, PlatformConnectionEntity>().ReverseMap();
        this.CreateMap<User, UserEntity>().ConvertUsing<UserToUserEntityConverter>();
        this.CreateMap<UserEntity, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.HashedPassword))
            .ForMember(dest => dest.PlatformConnections, opt => opt.MapFrom(src => src.PlatformConnections));
    }
}
