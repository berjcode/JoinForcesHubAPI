using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public  interface IAuthenticationService
{
    Task<ResponseDto<AuthenticationResult>> Login(LoginRequest loginRequest);
    Task<ResponseDto<AuthenticationResult>> Register(RegisterRequest registerRequest);
}
