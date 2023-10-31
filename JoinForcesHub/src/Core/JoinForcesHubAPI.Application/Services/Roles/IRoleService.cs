using JoinForcesHubAPI.Application.Contracts.Roles;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;

namespace JoinForcesHubAPI.Application.Services.Roles;

public interface IRoleService
{
    // Query
    Task<ResponseDto<int>> CountRoleAsync();
    Task<ResponseDto<RoleDto>> GetAsync(int roleId);
    Task<ResponseDto<RoleListDto>> GetAllByDeletedAsync();
    Task<ResponseDto<RoleUpdateDto>> UpdateRoleAsync(RoleDto roleDto);
    Task<ResponseDto<RoleListDto>> GetAllByNonDeletedActiveAsync();

    // Command
    Task<ResponseDto<bool>> HardDeleteRole(Guid roleId);
    Task<ResponseDto<bool>> SoftDeleteRole(RoleRemoveDto roleRemoveDto);
    Task<ResponseDto<RoleUpdateDto>> UpdateRole(RoleUpdateDto roleUpdateDto);
    Task<ResponseDto<bool>> CreateRoleAsync(RoleCreateDto roleCreateDto, CancellationToken cancellationToken);

}
