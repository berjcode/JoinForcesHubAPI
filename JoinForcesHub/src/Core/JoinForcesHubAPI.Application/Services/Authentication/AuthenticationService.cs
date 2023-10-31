using AutoMapper;
using JoinForcesHubAPI.Domain.Enums;
using JoinForcesHub.Domain.Entities.User;
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

        if (IsExistsRegisterForUserName(registerRequest.UserName) == true)
            throw new Exception(ServiceExceptionMessages.UserAlreadyRegistered);


        user.CreationDate = DateTime.UtcNow;
        user.CreatedByUserName = user.UserName;
        await _userCommandRepository.AddAsync(user);

        List<string> roles = new List<string>();
        roles.Add(AppSettingExpression.MemberRegisterExpression);

        var tokenRegister = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roles);
        var authResult = new AuthenticationResultDto(user.Id, user.FirstName, user.SurName, user.Email, tokenRegister);

        return ResponseDto<AuthenticationResultDto>.Success(authResult, (int)ApiStatusCode.Create, ApiMessages.RegisterSuccess);
    }

    public async Task<ResponseDto<AuthenticationResultDto>> Login(LoginRequest loginRequest)
    {
        var checkEmailByUser = await _userQueryRepository.GetUserByEmail(loginRequest.Email);

        if (checkEmailByUser == null)
            throw new Exception(ServiceExceptionMessages.ThisUserNotRegister);

        if (checkEmailByUser.Password != loginRequest.Password)
            throw new Exception(ServiceExceptionMessages.InvalidPassword);

        //
        List<string> roles = new List<string>();
        roles.Add("Üye");
        //

        var token = _jwtTokenGenerator.GenerateToken(checkEmailByUser.Id, checkEmailByUser.FirstName, checkEmailByUser.SurName, roles);
        var authResult = new AuthenticationResultDto(checkEmailByUser.Id, checkEmailByUser.FirstName, checkEmailByUser.SurName, checkEmailByUser.Email, token);

        return ResponseDto<AuthenticationResultDto>.Success(authResult, (int)ApiStatusCode.Success, ApiMessages.LoginSuccessful);
    }

    #region HelperMethods
    //Private 
    private bool IsExistsRegisterForUserName(string userName)
    {
        var result = _userQueryRepository.GetWhere(x => x.UserName == userName && x.IsDeleted == false).FirstOrDefault();
        if (result != null)
            return true;

        return false;
    }
    #endregion
}
