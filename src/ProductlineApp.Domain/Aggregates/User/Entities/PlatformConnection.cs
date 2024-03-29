using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.User.Entities;

public sealed class PlatformConnection : Entity<PlatformConnectionId>
{
    private PlatformConnection(
        PlatformConnectionId id,
        UserId userId,
        PlatformId platformId,
        string accessToken,
        string refreshToken,
        DateTime expirationDate,
        DateTime? refreshTokenExpirationDate)
    : base(id)
    {
        this.Id = id;
        this.UserId = userId;
        this.PlatformId = platformId;
        this.AccessToken = accessToken;
        this.ExpirationDate = expirationDate;
        this.RefreshToken = refreshToken;
        this.RefreshTokenExpirationDate = refreshTokenExpirationDate;
    }

    public PlatformConnectionId Id { get; private init; }

    public UserId UserId { get; private init; }

    public PlatformId PlatformId { get; private init; }

    public string AccessToken { get; private set; }

    public string RefreshToken { get; private set; }

    public DateTime ExpirationDate { get; private set; }

    public DateTime? RefreshTokenExpirationDate { get; private set; }

    public static PlatformConnection Create(
        User user,
        PlatformId platformId,
        string accessToken,
        string refreshToken,
        DateTime expirationDate,
        DateTime? refreshTokenExpirationDate)
    {
        if (string.IsNullOrEmpty(accessToken))
            throw new ArgumentException("Access token cannot be null or empty");

        if (string.IsNullOrEmpty(refreshToken))
            throw new ArgumentException("Access token cannot be null or empty");

        if (expirationDate < DateTime.UtcNow)
            throw new ArgumentException("Expiration date must be in the future");

        var id = PlatformConnectionId.CreateUnique();

        // bool userHasConnection = user.PlatformConnections.Any(c =>
        //     c.PlatformId == platformId && c.Id != id);
        // if (userHasConnection)
        // {
        //     throw new InvalidOperationException("User already has a connection to this platform");
        // }

        return new PlatformConnection(
            id,
            user.Id,
            platformId,
            accessToken,
            refreshToken,
            expirationDate,
            refreshTokenExpirationDate);
    }

    public void RefreshAccessToken(string newAccessToken, DateTime newAccessTokenExpiration)
    {
        if (newAccessTokenExpiration < DateTime.UtcNow)
        {
            throw new ArgumentException("Access token cannot be expired");
        }

        this.AccessToken = newAccessToken;
        this.ExpirationDate = newAccessTokenExpiration;
    }

    public void RefreshAccessToken(string newAccessToken, string newRefreshToken, DateTime newAccessTokenExpiration)
    {
        this.RefreshAccessToken(newAccessToken, newAccessTokenExpiration);
        this.RefreshToken = newRefreshToken;
    }

    public bool TokenNeedsRefresh()
    {
        return this.ExpirationDate < DateTime.UtcNow;
    }
}
