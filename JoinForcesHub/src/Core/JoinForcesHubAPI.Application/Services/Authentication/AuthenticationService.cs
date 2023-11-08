﻿using AutoMapper;
using FluentValidation;
using JoinForcesHubAPI.Domain.Enums;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHubAPI.Application.Abstractions;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubWeb.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Services.UserRoles;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public class AuthenticationService : BaseService<User>, IAuthenticationService
{

    private readonly IValidator<User> _userValidator;
    private readonly IUserRoleService _userRoleService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;

    public AuthenticationService(
        IMapper mapper,
        IValidator<User> userValidator,
        IUserRoleService userRoleService,
        IJwtTokenGenerator jwtTokenGenerator,
        IUserQueryRepository userQueryRepository,
        IUserCommandRepository userCommandRepository)
        : base(mapper)
    {
        _userValidator = userValidator;
        _userRoleService = userRoleService;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
    }


    public async Task<ResponseDto<AuthenticationResultDto>> Register(RegisterRequest registerRequest)
    {
        var user = _mapper.Map<User>(registerRequest);

        var validationResult = _userValidator.Validate(user);

        if (!validationResult.IsValid)
            return ResponseDto<AuthenticationResultDto>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList(), (int)ApiStatusCode.BadRequest);

        if (await _userQueryRepository.GetUserByEmail(user.Email) != null)
            return ResponseDto<AuthenticationResultDto>.Fail(ServiceExceptionMessages.UserWithGivenEmailNotExist, (int)ApiStatusCode.BadRequest);

        if (IsExistsRegisterForUserName(registerRequest.UserName) == true)
            return ResponseDto<AuthenticationResultDto>.Fail(ServiceExceptionMessages.UserAlreadyRegistered, (int)ApiStatusCode.BadRequest);


        user.CreationDate = DateTime.UtcNow;
        user.CreatedByUserName = user.UserName;
        await _userCommandRepository.AddAsync(user);

        List<string> roles = new List<string>();
        roles.Add(AppSettingExpression.MemberRegisterExpression);

        var tokenRegister = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roles);
        var authResult = new AuthenticationResultDto(user.Id, user.FirstName, user.SurName, user.Email, tokenRegister.AccessToken, tokenRegister.AccessTokenExpiration, null, null);
        return ResponseDto<AuthenticationResultDto>.Success(authResult, (int)ApiStatusCode.Create, ApiMessages.RegisterSuccess);
    }

    public async Task<ResponseDto<AuthenticationResultDto>> Login(LoginRequest loginRequest)
    {
        var user = await _userQueryRepository.GetUserByEmail(loginRequest.Email);

        if (user == null)
            throw new Exception(ServiceExceptionMessages.ThisUserNotRegister);

        if (user.Password != loginRequest.Password)
            throw new Exception(ServiceExceptionMessages.InvalidPassword);


        var getUserRoles = await _userRoleService.GetRoleByUserAsync(user.Id);
        var roleNames = getUserRoles.Select(ur => ur.RolesRoleName).ToList();


        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roleNames);


        if (user.RefreshToken.Length == 0 && user.RefreshTokenEndData == null)
            await UpdateRefreshToken(token.RefreshToken, token.RefreshTokenExpiration, 20, user.Id);


        var authResult = new AuthenticationResultDto(user.Id, user.FirstName, user.SurName, user.Email, token.AccessToken, token.AccessTokenExpiration, user.RefreshToken, token.RefreshTokenExpiration);

        return ResponseDto<AuthenticationResultDto>.Success(authResult, (int)ApiStatusCode.Success, ApiMessages.LoginSuccessful);
    }

    #region HelperMethods
    private bool IsExistsRegisterForUserName(string userName)
    {
        var result = _userQueryRepository.GetWhere(x => x.UserName == userName && x.IsDeleted == false).FirstOrDefault();
        if (result != null)
            return true;

        return false;
    }

    public async Task UpdateRefreshToken(string refreshToken, DateTime? accessTokenDate, int refreshTokenLifeTime, Guid userId)
    {
        var user = await _userQueryRepository.GetFirstExpression(x => x.Id == userId);
        if (user != null)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndData = accessTokenDate?.AddMinutes(refreshTokenLifeTime);

            _userCommandRepository.Update(user);
        }
    }

    public async Task<ResponseDto<NoDataDto>> RevokeRefreshToken(string refreshToken)
    {
        var existRefreshToken = await _userQueryRepository.GetFirstExpression(x => x.RefreshToken == refreshToken && x.RefreshTokenEndData > DateTime.UtcNow);

        if (existRefreshToken == null)
            return ResponseDto<NoDataDto>.Fail(ApiMessages.NotFoundRefreshtoken, 404);

        await UpdateRefreshToken("", DateTime.Now, 0, existRefreshToken.Id);

        return ResponseDto<NoDataDto>.Success(null, 200);
    }

    public async Task<ResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
    {
        var existRefreshToken = await _userQueryRepository.GetFirstExpression(x => x.RefreshToken == refreshToken && x.RefreshTokenEndData > DateTime.UtcNow);

        if (existRefreshToken == null)
            return ResponseDto<TokenDto>.Fail(ApiMessages.NotFoundRefreshtoken, 404);

        var getUserRoles = await _userRoleService.GetRoleByUserAsync(existRefreshToken.Id);
        var roleNames = getUserRoles.Select(ur => ur.RolesRoleName).ToList();

        var token = _jwtTokenGenerator.GenerateToken(existRefreshToken.Id, existRefreshToken.FirstName, existRefreshToken.SurName, roleNames);

        DateTime? nullDatetime = null;
        await UpdateRefreshToken("", nullDatetime, 0, existRefreshToken.Id);


        return ResponseDto<TokenDto>.Success(token, 200);
    }
    #endregion
}
