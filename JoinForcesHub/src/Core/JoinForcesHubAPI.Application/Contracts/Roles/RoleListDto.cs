namespace JoinForcesHubAPI.Application.Contracts.Roles;

public record RoleListDto(
    Guid Id,
    string RoleName,
    string Description,
    bool IsActive
    );
