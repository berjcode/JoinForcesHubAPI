using System.Text;
using System.Security.Cryptography;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;


namespace JoinForcesHubAPI.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public PasswordDto HashPassword(string password)
    {
        string generateSalt = GenerateSalt();
        string newHashPassword = SHA512HashPasswordAsync(password, generateSalt);
        PasswordDto passwordDto = new(PasswordHash: newHashPassword, Salt: generateSalt);

        return passwordDto;
    }

    public bool VerifyPassword(string password, string salt, string hashedPassword)
    {
        string newHashedPassword = SHA512HashPasswordAsync(password, salt);

        return string.Equals(newHashedPassword, hashedPassword, StringComparison.Ordinal);
    }
    private string BCryptHashPasswordAsync(string password, string salt)
    {
        return BCrypt.Net.BCrypt.HashPassword(password + salt);
    }

    private string GenerateSalt()
    {
        byte[] randomBytes = new byte[32];

        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            random.GetBytes(randomBytes);

        return Convert.ToBase64String(randomBytes);
    }
    private string SHA512HashPasswordAsync(string password, string salt)
    {
        using (SHA512Managed sha512 = new SHA512Managed())
        {
            byte[] data = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sha512.ComputeHash(data);

            return Convert.ToBase64String(hash);
        }
    }
}
