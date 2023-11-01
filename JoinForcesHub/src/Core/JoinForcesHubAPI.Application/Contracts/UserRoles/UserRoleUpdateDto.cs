namespace JoinForcesHubAPI.Application.Contracts.UserRoles;

public record UserRoleUpdateDto(
    Guid Id,
    Guid RoleId,
    Guid UserId,
    string IsActive,
    string UpdatedByUserName
    );
