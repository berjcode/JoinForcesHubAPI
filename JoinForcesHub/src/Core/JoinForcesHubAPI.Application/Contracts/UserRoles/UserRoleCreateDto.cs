namespace JoinForcesHubAPI.Application.Contracts.UserRoles;

public record UserRoleCreateDto(
    Guid RoleId,
    Guid UserId,
    string CreatedByUserName
    );
