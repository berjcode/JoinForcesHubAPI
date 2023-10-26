using JoinForcesHub.Domain.Entities;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public AuthenticationResult Register(string firstName, string surName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception(ServiceExceptionMessages.UserWithGivenEmailNotExist);
        }

        var user = new User
        {
            FirstName = firstName,
            SurName = surName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        var tokenRegister = _jwtTokenGenerator.GenerateToken(user.Id, firstName, surName);

        return new AuthenticationResult(Guid.NewGuid(), firstName, surName, email, tokenRegister);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception(ServiceExceptionMessages.UserWithGivenEmailNotExist);
        }

        if (user.Password != password)
        {
            throw new Exception(ServiceExceptionMessages.InvalidPassword);
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName);


        return new AuthenticationResult(
            user.Id, user.FirstName, user.SurName, user.SurName, token
            );

    }
}
