using JoinForcesHubAPI.Application.Contracts.UserRoles;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;

namespace JoinForcesHubAPI.Application.Services.UserRoles;

public interface IUserRoleService
{
    Task<ResponseDto<int>> CountUserRoleAsync();
    Task<List<UserRolesByUserIdListDto>> GetRoleByUserAsync(Guid userId);
    Task<ResponseDto<UserRoleListDto>> GetAllByDeletedAsync();
    Task<ResponseDto<UserRoleListDto>> GetAllByNonDeletedActiveAsync();
    Task<ResponseDto<UserRoleUpdateDto>> UpdateUserRoleAsync(UserRoleUpdateDto userRoleDto);

    // Command
    Task<ResponseDto<bool>> HardDeleteUserRoleAsync(Guid userRoleId,CancellationToken cancellationToken);
    Task<ResponseDto<bool>> SoftDeleteUserRoleAsync(UserRoleRemoveDto userRoleRemoveDto);
    Task<ResponseDto<bool>> CreateUserRoleAsync(UserRoleCreateDto userRoleCreateDto, CancellationToken cancellationToken);
}
