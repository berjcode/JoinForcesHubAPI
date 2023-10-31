namespace JoinForcesHubAPI.Application.Contracts.Roles;

public record RoleUpdateDto(
    Guid Id,
    string RoleName,
    string Description,
    string IsActive,
    string UpdatedByUserName
    );
