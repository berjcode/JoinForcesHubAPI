using AutoMapper;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Application.Enums;
using JoinForcesHubAPI.Application.Abstractions;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubWeb.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public class AuthenticationService : BaseService<User>, IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;

    public AuthenticationService(
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator,
        IUserQueryRepository userQueryRepository,
        IUserCommandRepository userCommandRepository) : base(mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
    }


    public async Task<ResponseDto<AuthenticationResultDto>> Register(RegisterRequest registerRequest)
    {
        var user = _mapper.Map<User>(registerRequest);

        if (await _userQueryRepository.GetUserByEmail(user.Email) != null)
            throw new Exception(ServiceExceptionMessages.UserWithGivenEmailNotExist);

        await _userCommandRepository.AddAsync(user);

        List<string> roles = new List<string>();
        roles.Add(AppSettingExpression.MemberRegisterExpression);

        var tokenRegister = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roles);
        var authResult = new AuthenticationResultDto(user.Id, user.FirstName, user.SurName, user.Email, tokenRegister);

        return ResponseDto<AuthenticationResultDto>.Success(authResult, (int)ApiStatusCode.Create, ApiMessages.RegisterSuccess);
    }

    public async Task<ResponseDto<AuthenticationResultDto>> Login(LoginRequest loginRequest)
    {
        if (await _userQueryRepository.GetUserByEmail(loginRequest.Email) is not User user)
            throw new Exception(ServiceExceptionMessages.UserWithGivenEmailNotExist);

        if (user.Password != loginRequest.Password)
            throw new Exception(ServiceExceptionMessages.InvalidPassword);

        //
        List<string> roles = new List<string>();
        roles.Add("Üye");
        //

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roles);
        var authResult = new AuthenticationResultDto(user.Id, user.FirstName, user.SurName, user.Email, token);

        return ResponseDto<AuthenticationResultDto>.Success(authResult, (int)ApiStatusCode.Success, ApiMessages.LoginSuccessful);
    }
}
