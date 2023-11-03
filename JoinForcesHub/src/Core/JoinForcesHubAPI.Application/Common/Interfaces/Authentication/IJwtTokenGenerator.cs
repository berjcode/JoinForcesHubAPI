using JoinForcesHubAPI.Application.Contracts.UserAuthentication;

namespace JoinForcesHubAPI.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateRefreshToken();
    TokenDto GenerateToken(Guid userId, string firstName, string surName, List<string> roles);


}
