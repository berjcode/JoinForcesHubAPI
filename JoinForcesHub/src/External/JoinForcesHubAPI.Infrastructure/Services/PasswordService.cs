using Azure.Core;
using System.Security.Cryptography;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;

namespace JoinForcesHubAPI.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public PasswordDto HashPassword(string password)
    {
        string generateSalt = GenerateSalt();
        string newHashPassword = BCryptHashPasswordAsync(password, generateSalt);

        PasswordDto passwordDto = new(PasswordHash: newHashPassword, Salt: generateSalt);
        return passwordDto;

    }

    public bool VerifyPassword(string password, string salt, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password + salt, hashedPassword);
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
}
