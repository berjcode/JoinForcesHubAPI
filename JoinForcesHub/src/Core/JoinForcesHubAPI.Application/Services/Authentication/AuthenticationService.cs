using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserQueryRepository userQueryRepository,
        IUserCommandRepository userCommandRepository
        )
    {

        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
    }


    public async Task<AuthenticationResult> Register(string firstName, string surName, string email, string password)
    {
        if (await _userQueryRepository.GetUserByEmail(email) != null)
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

       await _userCommandRepository.AddAsync(user);

        var tokenRegister = _jwtTokenGenerator.GenerateToken(user.Id, firstName, surName);

        return new AuthenticationResult(Guid.NewGuid(), firstName, surName, email, tokenRegister);
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        if (await _userQueryRepository.GetUserByEmail(email) is not User user)
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
