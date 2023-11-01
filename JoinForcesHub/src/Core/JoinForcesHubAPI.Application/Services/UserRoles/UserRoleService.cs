using AutoMapper;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Application.Abstractions;
using JoinForcesHubAPI.Application.Contracts.UserRoles;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;
using FluentValidation;
using JoinForcesHubAPI.Domain.Enums;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubWeb.Application.Utilities.Messages;

namespace JoinForcesHubAPI.Application.Services.UserRoles;

public class UserRoleService : BaseService<UserRole>, IUserRoleService
{

    private readonly IValidator<UserRole> _userRoleValidator;
    private readonly IUserRoleQueryRepository _userRolequeryRepository;
    private readonly IUserRoleCommandRepository _userRolecommandRepository;
    public UserRoleService(
        IMapper mapper,
        IValidator<UserRole> userRoleValidator,
        IUserRoleQueryRepository userRolequeryRepository,
        IUserRoleCommandRepository userRolecommandRepository
        ) : base(mapper)
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

        var checkUserRole = await _userRolequeryRepository
            .CountAsync(x => x.UserId == userRoleCreateDto.UserId && x.RoleId == userRoleCreateDto.RoleId);
        if (checkUserRole > 0)
            throw new Exception(ServiceExceptionMessages.RoleAlreadyRegistered);

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

    public Task<ResponseDto<UserRoleDto>> GetAsync(int roleId)
    {
        throw new NotImplementedException();
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
