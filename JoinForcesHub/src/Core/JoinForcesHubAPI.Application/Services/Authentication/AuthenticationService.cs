using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }


    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check User

        Guid userId = Guid.NewGuid();

        var tokenRegister = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(Guid.NewGuid(),firstName, lastName, email, tokenRegister);
    }

    public AuthenticationResult Login(string firstName, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), "Abdullah", "lastName", "lastName", "token"
            );
     
    }
}
