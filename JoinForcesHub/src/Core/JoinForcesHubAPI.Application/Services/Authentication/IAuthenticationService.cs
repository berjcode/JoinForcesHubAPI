using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public  interface IAuthenticationService
{
    Task UpdateRefreshToken(string refreshToken, DateTime accessTokenDate, int refreshTokenLifeTime, Guid userId);
    Task<ResponseDto<AuthenticationResultDto>> Login(LoginRequest loginRequest);
    Task<ResponseDto<AuthenticationResultDto>> Register(RegisterRequest registerRequest);
}
