using AutoMapper;
using FluentValidation;
using JoinForcesHubAPI.Domain.Enums;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Application.Abstractions;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubWeb.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Contracts.UserRoles;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

namespace JoinForcesHubAPI.Application.Services.UserRoles;

public class UserRoleService : BaseService<UserRole>, IUserRoleService
{

    private readonly IValidator<UserRole> _userRoleValidator;
    private readonly IUserRoleQueryRepository _userRolequeryRepository;
    private readonly IUserRoleCommandRepository _userRolecommandRepository;
    public UserRoleService(
        IMapper mapper,
        IDateTimeProvider dateTimeProvider,
        IDbContextService dbContextService,
        IValidator<UserRole> userRoleValidator,
        IUserRoleQueryRepository userRolequeryRepository,
        IUserRoleCommandRepository userRolecommandRepository
      ) : base(mapper, dateTimeProvider, dbContextService)
    {
        _userRoleValidator = userRoleValidator;
        _userRolequeryRepository = userRolequeryRepository;
        _userRolecommandRepository = userRolecommandRepository;
    }

    public Task<ResponseDto<int>> CountUserRoleAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseDto<bool>> CreateUserRoleAsync(UserRoleCreateDto userRoleCreateDto, CancellationToken cancellationToken)
    {
        var userRole = _mapper.Map<UserRole>(userRoleCreateDto);
        var validationResult = _userRoleValidator.Validate(userRole);
        if (!validationResult.IsValid)
            return ResponseDto<bool>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList(), (int)ApiStatusCode.BadRequest);

        if (await _userRolequeryRepository.AnyAsync(x => x.UserId == userRoleCreateDto.UserId && x.RoleId == userRoleCreateDto.RoleId))
            return ResponseDto<bool>.Fail(ServiceExceptionMessages.RoleAlreadyRegistered, (int)ApiStatusCode.BadRequest);

        userRole.CreationDate = DateTime.UtcNow;
        userRole.CreatedByUserName = userRoleCreateDto.CreatedByUserName;

        await _userRolecommandRepository.AddAsync(userRole, cancellationToken);

        return ResponseDto<bool>.Success(true, (int)ApiStatusCode.Create, ApiMessages.RegisterSuccess);
    }

    public Task<ResponseDto<UserRoleListDto>> GetAllByDeletedAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<UserRoleListDto>> GetAllByNonDeletedActiveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserRolesByUserIdListDto>> GetRoleByUserAsync(Guid userId)
    {
        var userRoles = await _userRolequeryRepository
            .GetAllExpressionAsync(ur => ur.UserId == userId, x => x.Users, x => x.Roles);

        var userListDto = _mapper.Map<List<UserRolesByUserIdListDto>>(userRoles);

        return userListDto;
    }

    public Task<ResponseDto<bool>> HardDeleteUserRoleAsync(Guid userRoleId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<bool>> SoftDeleteUserRoleAsync(UserRoleRemoveDto userRoleRemoveDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<UserRoleUpdateDto>> UpdateUserRoleAsync(UserRoleUpdateDto userRoleDto)
    {
        throw new NotImplementedException();
    }
}
