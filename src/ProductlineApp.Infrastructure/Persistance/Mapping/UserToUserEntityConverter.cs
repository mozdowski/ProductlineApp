using AutoMapper;
using ProductlineApp.Application.Security;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Infrastructure.Persistance.Entities.User;

namespace ProductlineApp.Infrastructure.Persistance.Mapping;

public class UserToUserEntityConverter : ITypeConverter<User, UserEntity>
{
    private readonly IPasswordHasher _passwordHasher;

    public UserToUserEntityConverter(
        IPasswordHasher passwordHasher)
    {
        this._passwordHasher = passwordHasher;
    }

    public UserEntity Convert(User source, UserEntity destination, ResolutionContext context)
    {
        destination ??= new UserEntity();

        destination.Id = source.Id;
        destination.Email = source.Email;
        destination.Username = source.Username;

        var pcs = context.Mapper.Map<ICollection<PlatformConnectionEntity>>(source.PlatformConnections);
        destination.PlatformConnections = pcs;

        var hashResult = this._passwordHasher.HashPassword(source.Password);
        destination.HashedPassword = hashResult.Hash;
        destination.Salt = hashResult.Salt;

        return destination;
    }
}
