namespace JoinForcesHubAPI.Application.Contracts.UserRoles;

public record UserRoleDto(
    Guid RoleId,
    string RoleName,
    Guid UserId,
    string UserName,
    bool IsActive
    );
