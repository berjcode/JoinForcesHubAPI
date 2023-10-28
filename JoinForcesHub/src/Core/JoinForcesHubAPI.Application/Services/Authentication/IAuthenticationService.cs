namespace JoinForcesHubAPI.Application.Services.Authentication;

public  interface IAuthenticationService
{
    Task<AuthenticationResult> Login(string firstName, string password);
    Task<AuthenticationResult>  Register(string firstName, string surName, string email, string password);
}
