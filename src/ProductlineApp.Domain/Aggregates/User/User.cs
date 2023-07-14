using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.User;

public sealed class User : AggregateRoot<UserId>
{
    private List<PlatformConnection> _platformConnections = new();

    private User(
        UserId id,
        string username,
        string password,
        string salt,
        string email)
        : base(id)
    {
        this.Username = username;
        this.Password = password;
        this.Salt = salt;
        this.Email = email;
    }

    private User()
    {
    }

    public string Username { get; private set; }

    public string Password { get; private set; }

    public string Salt { get; private set; }

    [EmailAddress]
    public string Email { get; private init; }

    public Image? Avatar { get; private set; }

    public IReadOnlyList<PlatformConnection> PlatformConnections
    {
        get => this._platformConnections.AsReadOnly();
        private init => this._platformConnections = value.ToList();
    }

    public static User Create(string username, string password, string salt, string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be empty.", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be empty.", nameof(password));
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be empty.", nameof(password));
        }

        if (string.IsNullOrWhiteSpace(salt))
        {
            throw new ArgumentException("Salt cannot be empty.", nameof(password));
        }

        return new User(
            UserId.CreateUnique(),
            username,
            password,
            salt,
            email);
    }

    public void AddPlatformConnection(PlatformId platformId, string accessToken, string refreshToken, int expiresIn, int? refreshTokenExpiresIn)
    {
        if (this._platformConnections.Any(pc => pc.PlatformId.Value == platformId.Value))
        {
            throw new ArgumentException($"User already has a connection to the platform with id {platformId}");
        }

        if (expiresIn < 0)
        {
            throw new ArgumentException("Invalid expiration time");
        }

        var expirationDate = DateTime.UtcNow.AddSeconds(expiresIn);
        if (refreshTokenExpiresIn.HasValue)
        {
            var refreshTokenExpirationDate = DateTime.UtcNow.AddSeconds(expiresIn);
            var platformConnection = PlatformConnection.Create(this, platformId, accessToken, refreshToken, expirationDate, refreshTokenExpirationDate);
            this._platformConnections.Add(platformConnection);
        }
        else
        {
            var platformConnection = PlatformConnection.Create(this, platformId, accessToken, refreshToken, expirationDate, null);
            this._platformConnections.Add(platformConnection);
        }
    }

    public void RemovePlatformConnection(PlatformId platformId)
    {
        var connection = this._platformConnections.FirstOrDefault(p => p.PlatformId == platformId);

        if (connection == null)
        {
            throw new ArgumentException($"User is not connected to platform with id {platformId}");
        }

        this._platformConnections.Remove(connection);
    }

    public void ChangePassword(string newPassword, string newSalt)
    {
        if (string.IsNullOrEmpty(newPassword))
            throw new ArgumentException("Password cannot be null or empty");

        if (string.IsNullOrEmpty(newSalt))
            throw new ArgumentException("salt cannot be empty");

        this.Password = newPassword;
        this.Salt = newSalt;
    }

    public void UpdateAvatar(Image avatar)
    {
        this.Avatar = avatar;
    }

    public IEnumerable<PlatformConnection> GetPlatformConnectionsToRefresh()
    {
        return this._platformConnections.Where(x => x.TokenNeedsRefresh());
    }

    public void RefreshAccessTokenForPlatform(PlatformId platformId, string newAccessToken, int expiresIn)
    {
        var newAccessTokenExpiration = DateTime.UtcNow.AddSeconds(expiresIn);

        var pc = this._platformConnections.First(x => x.PlatformId == platformId);
        pc.RefreshAccessToken(newAccessToken, newAccessTokenExpiration);
    }

    public void RefreshAccessTokenForPlatform(PlatformId platformId, string newAccessToken, string newRefreshToken, int expiresIn)
    {
        var newAccessTokenExpiration = DateTime.UtcNow.AddSeconds(expiresIn);

        var pc = this._platformConnections.First(x => x.PlatformId == platformId);
        pc.RefreshAccessToken(newAccessToken, newRefreshToken, newAccessTokenExpiration);
    }

    private void ChangeUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            throw new ArgumentException("New username cannot be null or empty");

        this.Username = username;
    }
}
