namespace JoinForcesHubAPI.Application.Contracts.UserRoles;

public record UserRoleListDto(
    Guid RoleId,
    string RoleName,
    Guid UserId,
    string UserName,
    bool IsActive,
    string CreatedByUserName
    );
