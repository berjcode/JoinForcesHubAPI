using JoinForcesHubAPI.Application.Contracts.Roles;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHub.Domain.Entities.Roles;

namespace JoinForcesHubAPI.Application.Services.Roles;

public interface IRoleService
{
    // Query
    Task<ResponseDto<int>> CountRoleAsync();
    Task<ResponseDto<RoleDto>> GetAsync(int roleId);
    Task<Role> GetByRoleNameAsync(string roleName);
    Task<ResponseDto<RoleListDto>> GetAllByDeletedAsync();
    Task<ResponseDto<RoleListDto>> GetAllByNonDeletedActiveAsync();
    Task<ResponseDto<RoleUpdateDto>> UpdateRoleAsync(RoleUpdateDto updateUpdateDto);

    // Command
    Task<ResponseDto<bool>> HardDeleteRole(Guid roleId);
    Task<ResponseDto<bool>> SoftDeleteRole(RoleRemoveDto roleRemoveDto);
    Task<ResponseDto<RoleUpdateDto>> UpdateRole(RoleUpdateDto roleUpdateDto);
    Task<ResponseDto<bool>> CreateRoleAsync(RoleCreateDto roleCreateDto, CancellationToken cancellationToken);

}
