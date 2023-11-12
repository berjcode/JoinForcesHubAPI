using JoinForcesHubAPI.Application.Contracts.UserAuthentication;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Services;

public interface IPasswordService
{
    PasswordDto HashPassword(string password);
    bool VerifyPassword(string password, string salt, string hashedPassword);
}
