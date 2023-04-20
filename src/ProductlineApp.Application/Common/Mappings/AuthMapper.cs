using AutoMapper;
using ProductlineApp.Application.Authentication.Commands;
using ProductlineApp.Application.Authentication.Queries;
using ProductlineApp.Shared.Models.Authentication.Requests.Auth;

namespace ProductlineApp.Application.Common.Mappings;

public class AuthMapper : Profile
{
    public AuthMapper()
    {
        this.CreateMap<RegisterRequest, RegisterCommand.Command>();
        this.CreateMap<LoginRequest, LoginQuery.Query>();
    }
}
