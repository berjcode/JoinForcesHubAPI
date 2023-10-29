using AutoMapper;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;

    public AuthenticationService(
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator,
        IUserQueryRepository userQueryRepository,
        IUserCommandRepository userCommandRepository)
    {

        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
    }


    public async Task<AuthenticationResult> Register(RegisterRequest registerRequest)
    {
        var user = _mapper.Map<User>(registerRequest);

        if (await _userQueryRepository.GetUserByEmail(user.Email) != null)
            throw new Exception(ServiceExceptionMessages.UserWithGivenEmailNotExist);

        await _userCommandRepository.AddAsync(user);

        List<string> roles = new List<string>();
        roles.Add(AppSettingExpression.MemberRegisterExpression);

        var tokenRegister = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roles);

        return new AuthenticationResult(Guid.NewGuid(), user.FirstName, user.SurName, user.Email, tokenRegister);
    }

    public async Task<AuthenticationResult> Login(string email, string password)
    {
        if (await _userQueryRepository.GetUserByEmail(email) is not User user)
            throw new Exception(ServiceExceptionMessages.UserWithGivenEmailNotExist);

        if (user.Password != password)
            throw new Exception(ServiceExceptionMessages.InvalidPassword);

        //
        List<string> roles = new List<string>();
        roles.Add("Üye");
        //

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roles);

        return new AuthenticationResult(user.Id, user.FirstName, user.SurName, user.SurName, token);
    }
}
