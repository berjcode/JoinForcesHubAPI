using AutoMapper;
using System.Data;
using FluentValidation;
using JoinForcesHub.Domain.Enums;
using JoinForcesHubAPI.Domain.Enums;
using JoinForcesHub.Domain.Entities.User;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Application.Abstractions;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubWeb.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Services.UserRoles;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Contracts.UserAuthentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Authentication;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.UserRepositories;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

namespace JoinForcesHubAPI.Application.Services.Authentication;

public class AuthenticationService : BaseService<User>, IAuthenticationService
{


    private readonly IValidator<User> _userValidator;
    private readonly IUserRoleService _userRoleService;
    private readonly IPasswordService _passwordService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IRoleCommandRepository _roleCommandRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private readonly IUserRoleCommandRepository _userRoleCommandRepository;


    public AuthenticationService(
        IMapper mapper,
        IValidator<User> userValidator,
        IUserRoleService userRoleService,
        IPasswordService passwordService,
        IDateTimeProvider dateTimeProvider,
        IDbContextService dbContextService,
        IJwtTokenGenerator jwtTokenGenerator,
        IUserQueryRepository userQueryRepository,
        IRoleQueryRepository roleQueryRepository,
        IRoleCommandRepository roleCommandRepository,
        IUserCommandRepository userCommandRepository,
        IUserRoleCommandRepository userRoleCommandRepository
        )
        : base(mapper, dateTimeProvider, dbContextService)
    {
        _userValidator = userValidator;
        _passwordService = passwordService;
        _userRoleService = userRoleService;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userQueryRepository = userQueryRepository;
        _roleQueryRepository = roleQueryRepository;
        _roleCommandRepository = roleCommandRepository;
        _userCommandRepository = userCommandRepository;
        _userRoleCommandRepository = userRoleCommandRepository;
    }


    public async Task<ResponseDto<AuthenticationResultDto>> Register(RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        using (var transaction = await _dbContextService.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                var user = _mapper.Map<User>(registerRequest);

                var validationResult = _userValidator.Validate(user);

                if (!validationResult.IsValid)
                    return ResponseDto<AuthenticationResultDto>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList(), (int)ApiStatusCode.BadRequest);

                if (await _userQueryRepository.GetUserByEmail(user.Email) != null)
                    return ResponseDto<AuthenticationResultDto>.Fail(ServiceExceptionMessages.UserWithGivenEmailNotExist, (int)ApiStatusCode.BadRequest);

                if (IsExistsRegisterForUserName(registerRequest.UserName))
                    return ResponseDto<AuthenticationResultDto>.Fail(ServiceExceptionMessages.UserAlreadyRegistered, (int)ApiStatusCode.BadRequest);

                var CreateFromUser = CreateUserFromUser(user);

                await _userCommandRepository.AddAsync(CreateFromUser);

                var roles = await CreateRoleAndUserRole(user, cancellationToken);

                await _dbContextService.SaveChangesAsync(cancellationToken);

                var tokenRegister = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roles);
                var authResult = new AuthenticationResultDto(user.Id, user.FirstName, user.SurName, user.Email, tokenRegister.AccessToken, tokenRegister.AccessTokenExpiration, default);
                transaction.Commit();
                return ResponseDto<AuthenticationResultDto>.Success(authResult, (int)ApiStatusCode.Create, ApiMessages.RegisterSuccess);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return ResponseDto<AuthenticationResultDto>.Fail(ex.Message, (int)ApiStatusCode.InternalServerError);
            }
        }
    }

    private async Task<List<string>> CreateRoleAndUserRole(User user, CancellationToken cancellationToken)
    {
        var checkDefaultRole = await _roleQueryRepository.GetFirstExpression(x => x.RoleName == AppSettingExpression.MemberRegisterExpression);

        List<string> roles = new List<string>();

        Role newRole = new Role
        {
            RoleName = AppSettingExpression.MemberRegisterExpression,
            CreatedByUserName = user.UserName,
            CreationDate = DateTime.Now,
            Description = AppSettingExpression.MemberRegisterDescription,
        };
        if (checkDefaultRole == null)
        {
            roles.Add(newRole.RoleName);
            await _roleCommandRepository.AddAsync(newRole, cancellationToken);
            UserRole userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = newRole.Id,
                CreatedByUserName = AppSettingExpression.MemberRegisterRoleForCreateBy,
                CreationDate = DateTime.Now,
            };
            await _userRoleCommandRepository.AddAsync(userRole, cancellationToken);
        }
        else
        {
            UserRole userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = checkDefaultRole.Id,
                CreatedByUserName = AppSettingExpression.MemberRegisterRoleForCreateBy,
                CreationDate = DateTime.Now,
            };

            await _userRoleCommandRepository.AddAsync(userRole, cancellationToken);
        }

        return roles;
    }

    public async Task<ResponseDto<AuthenticationResultDto>> Login(LoginRequest loginRequest)
    {
        var user = await _userQueryRepository.GetUserByEmail(loginRequest.Email);

        if (user == null)
            throw new Exception(ServiceExceptionMessages.ThisUserNotRegister);

        var isPasswordValid = _passwordService.VerifyPassword(loginRequest.Password, user.Salt, user.PasswordHash);

        if (!isPasswordValid)
            throw new Exception(ServiceExceptionMessages.InvalidPassword);

        if (user.RefreshTokenEndData < _dateTimeProvider.NowTime)
            await UpdateRefreshToken(string.Empty, default, (int)RefreshTokenTime.Zero, user.Id);

        var getUserRoles = await _userRoleService.GetRoleByUserAsync(user.Id);
        var roleNames = getUserRoles.Select(ur => ur.RolesRoleName).ToList();

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.SurName, roleNames);

        if (user.RefreshToken.Length == 0 && user.RefreshTokenEndData == null)
            await UpdateRefreshToken(token.RefreshToken, token.RefreshTokenExpiration, (int)RefreshTokenTime.Twenty, user.Id);

        var authResult = new AuthenticationResultDto(user.Id, user.FirstName, user.SurName, user.Email, token.AccessToken, token.AccessTokenExpiration, user.RefreshToken);

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

    private User CreateUserFromUser(User user)
    {
        var userPasswordHash = _passwordService.HashPassword(user.PasswordHash);
        user.RefreshToken = string.Empty;
        user.TwoFactorEnabled = false;
        user.RefreshTokenEndData = default;
        user.CreationDate = DateTime.Now;
        user.Salt = userPasswordHash.Salt;
        user.CreatedByUserName = user.UserName;
        user.PasswordHash = userPasswordHash.PasswordHash;

        return user;
    }

    private async Task UpdateRefreshToken(string refreshToken, DateTime? accessTokenDate, int refreshTokenLifeTime, Guid userId)
    {
        var user = await _userQueryRepository.GetFirstExpression(x => x.Id == userId);
        if (user != null)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndData = accessTokenDate?.AddMinutes(refreshTokenLifeTime);

            _userCommandRepository.Update(user);
        }
    }

    public async Task<ResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
    {
        var existRefreshToken = await _userQueryRepository.GetFirstExpression(x => x.RefreshToken == refreshToken && x.RefreshTokenEndData > _dateTimeProvider.NowTime);

        if (existRefreshToken == null)
            return ResponseDto<TokenDto>.Fail(ApiMessages.NotFoundRefreshtoken, (int)ApiStatusCode.BadRequest);

        var getUserRoles = await _userRoleService.GetRoleByUserAsync(existRefreshToken.Id);
        var roleNames = getUserRoles.Select(ur => ur.RolesRoleName).ToList();

        var token = _jwtTokenGenerator.GenerateToken(existRefreshToken.Id, existRefreshToken.FirstName, existRefreshToken.SurName, roleNames);

        DateTime? nullDatetime = null;
        await UpdateRefreshToken("", nullDatetime, (int)RefreshTokenTime.Zero, existRefreshToken.Id);

        return ResponseDto<TokenDto>.Success(token, (int)ApiStatusCode.Success);
    }
    #endregion
}
