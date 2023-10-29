using JoinForcesHubAPI.Application.Contracts.UserAuthentication;
using JoinForcesHubAPI.Application.Contracts.Users;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public  interface IAuthenticationService
{
    Task<AuthenticationResult> Login(string firstName, string password);
    Task<AuthenticationResult> Register(RegisterRequest registerRequest);
}
