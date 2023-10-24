namespace JoinForcesHubAPI.Application.Services.Authentication;

public  interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string surName, string email, string password);
    AuthenticationResult Login(string firstName, string password);
}
