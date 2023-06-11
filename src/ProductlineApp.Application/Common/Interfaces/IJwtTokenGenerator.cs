namespace ProductlineApp.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateToken(Domain.Aggregates.User.User user);
}
