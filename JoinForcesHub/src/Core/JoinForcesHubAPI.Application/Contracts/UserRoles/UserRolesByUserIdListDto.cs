namespace JoinForcesHubAPI.Application.Contracts.UserRoles;

public record UserRolesByUserIdListDto(
     Guid RoleId,
    string RolesRoleName,
    Guid UserId,
    string UsersUserName
    );
