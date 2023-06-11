using ProductlineApp.Application.Security;
using System.Security.Cryptography;

namespace ProductlineApp.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 20;
    private const int Iterations = 10000;

    public PasswordHashResult HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[SaltSize];
        rng.GetBytes(salt);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);
        var hash = pbkdf2.GetBytes(HashSize);

        var saltString = Convert.ToBase64String(salt);
        var hashString = Convert.ToBase64String(hash);

        return new PasswordHashResult(hashString, saltString);
    }

    public bool VerifyPassword(string password, string hashedPassword, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var hashBytes = Convert.FromBase64String(hashedPassword);

        var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA512);
        var newHash = pbkdf2.GetBytes(HashSize);

        return newHash.SequenceEqual(hashBytes);
    }
}
