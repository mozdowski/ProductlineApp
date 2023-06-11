namespace ProductlineApp.Application.Security;

public interface IPasswordHasher
{
    PasswordHashResult HashPassword(string password);

    bool VerifyPassword(string password, string hashedPassword, string salt);
}
